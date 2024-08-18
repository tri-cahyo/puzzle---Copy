using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject[] puzzles; // Array yang berisi semua jenis puzzle
    [SerializeField]
    private AudioClip[] animalSounds; // Array yang berisi suara hewan sesuai dengan urutan puzzle

    private AudioClip currentAnimalSound; // Suara hewan yang akan dimainkan saat menang

    public GameObject pausePanel, menuPanel, tutorialPanel;
    private bool isMusicMuted = false;
    private bool isSFXMuted = false;
    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindAnyObjectByType<GameControl>();
        SelectRandomPuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fungsi ini akan dipanggil saat gambar di klik
    public void RotateImage(Transform imageTransform)
    {
        if (GameControl.youWin || GameControl.youLose)
        {
            Debug.Log("Done bang");
            return;
        }
        imageTransform.Rotate(0, 0, 90);
    }
    public void btnPause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        menuPanel.SetActive(false);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }
    public void openTutorial()
    {
        tutorialPanel.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }
    public void closeTutorial()
    {
        tutorialPanel.SetActive(false);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void btnResume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        menuPanel.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void btnHome()
    {
        SceneManager.LoadScene(1);
        audioManager.instance.PlaySFX(audioManager.instance.click);
        audioManager.instance.ChangeMusic(0);
    }

    public void btnRestart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        audioManager.instance.PlaySFX(audioManager.instance.click);
        audioManager.instance.ChangeMusic(0);
    }
    
    public void muteBtn()
    {
        isSFXMuted = !isSFXMuted;
        audioManager.instance.MuteSFX(isSFXMuted);
        isMusicMuted = !isMusicMuted;
        audioManager.instance.MuteMusic(isMusicMuted);
        Debug.Log("mute");

    }
    void SelectRandomPuzzle()
    {
        // Nonaktifkan semua puzzle
        foreach (GameObject puzzle in puzzles)
        {
            Debug.Log("matikan game");
            puzzle.SetActive(false);
        }

        // Pilih satu puzzle secara acak dan aktifkan
        int randomIndex = UnityEngine.Random.Range(0, puzzles.Length);
        puzzles[randomIndex].SetActive(true);
        // Simpan suara hewan yang sesuai dengan puzzle yang dipilih
        currentAnimalSound = animalSounds[randomIndex];
    }
    public AudioClip GetCurrentAnimalSound()
    {
        return currentAnimalSound;
    }

}
