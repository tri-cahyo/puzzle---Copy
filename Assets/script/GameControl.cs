using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    public GameObject winPanel, losePanel, gamePanel, MenuPanel;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject[] starIcons;  // Referensi ke ikon bintang di UI
    private float timer = 10f;
    private float winTime; // Menyimpan waktu saat menang
    private bool gameWon = false; // Status kemenangan

    public static bool youWin, youLose;

    void Start()
    {
        winPanel.SetActive(false);
        youWin = false;
        youLose = false;

        // Memastikan semua ikon bintang tidak terlihat di awal
        foreach (var star in starIcons)
        {
            star.SetActive(false);
        }
    }

    void Update()
    {
        if (!gameWon)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0f)
            {
                timer = 0;
                youLose = true;
                losePanel.SetActive(true);
                timerText.color = Color.red;
            }

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Memeriksa setiap gambar dalam array pictures
            for (int i = 0; i < pictures.Length; i++)
            {
                if (pictures[i].rotation.z != 0)
                {
                    return;
                }
            }

            // Ketika pemain menang
            Debug.Log("win");
            youWin = true;
            gameWon = true; // Set status kemenangan

            // Simpan waktu tersisa saat menang
            winTime = timer;

            // Gantikan musik dengan suara hewan saat menang
            AudioClip animalSound = FindObjectOfType<gameSetting>().GetCurrentAnimalSound();
            audioManager.instance.PlayAnimalSound(animalSound);

            // Lakukan perubahan UI setelah musik diganti
            gamePanel.SetActive(false);
            MenuPanel.SetActive(false);
            winPanel.SetActive(true);

            // Menghitung jumlah bintang berdasarkan sisa waktu
            int starCount = CalculateStars(winTime);
            DisplayStars(starCount);
        }
    }

    // Fungsi untuk menghitung jumlah bintang berdasarkan sisa waktu
    private int CalculateStars(float remainingTime)
    {
        if (remainingTime >= 7f)
        {
            return 3;  // 3 bintang jika waktu yang tersisa lebih dari atau sama dengan 7 detik
        }
        else if (remainingTime >= 3f)
        {
            return 2;  // 2 bintang jika waktu yang tersisa antara 3 detik dan 7 detik
        }
        else
        {
            return 1;  // 1 bintang jika waktu yang tersisa kurang dari 3 detik
        }
    }

    // Fungsi untuk menampilkan bintang di UI
    private void DisplayStars(int starCount)
    {
        for (int i = 0; i < starCount; i++)
        {
            if (i < starIcons.Length)
            {
                starIcons[i].SetActive(true);  // Menampilkan bintang sesuai dengan jumlah yang dihitung
            }
        }
    }
}
