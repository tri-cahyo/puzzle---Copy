using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public static audioManager instance { get; set; }
    int sound;
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip[] clipMusics;

    [Header("SFX Clip")]
    public AudioClip click;

    private bool isMusicMuted = false;
    private bool isSFXMuted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ChangeMusic(int quizPlay)
    {
        int i = quizPlay;

        musicSource.Stop();
        musicSource.clip = clipMusics[i];
        musicSource.Play();
    }

    public void MuteMusic(bool mute)
    {
        isMusicMuted = mute;
        musicSource.mute = mute;
    }

    public void MuteSFX(bool mute)
    {
        isSFXMuted = mute;
        SFXSource.mute = mute;
    }

    public void PlayAnimalSound(AudioClip animalSound)
{
    musicSource.Stop();
    musicSource.clip = animalSound;
    musicSource.Play();
}
}
