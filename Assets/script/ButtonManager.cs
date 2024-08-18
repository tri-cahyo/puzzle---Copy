using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject homeMenu, setting, settingButton,tutorial, kategoriMenu, omnivoraLevel, herbivoraLevel, karnivoraLevel;
    private bool isMusicMuted = false;
    private bool isSFXMuted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string LevelName)
    {
        SceneManager.LoadSceneAsync(LevelName);
    }
    
    public void playButton()
    {
        homeMenu.SetActive(false);
        kategoriMenu.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void backToHome()
    {
        kategoriMenu.SetActive(false);
        homeMenu.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void openSetting()
    {
        setting.SetActive(true);
        settingButton.SetActive(false);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void closeSetting()
    {
        setting.SetActive(false);
        settingButton.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void openTutorial()
    {
        setting.SetActive(false);
        tutorial.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }
    public void closeTutorial()
    {
        setting.SetActive(true);
        tutorial.SetActive(false);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void btnKarnivoraLevel()
    {
        kategoriMenu.SetActive(false);
        karnivoraLevel.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }
    public void btnHerbivoraLevel()
    {
        kategoriMenu.SetActive(false);
        herbivoraLevel.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void btnOmnivoraLevel()
    {
        kategoriMenu.SetActive(false);
        omnivoraLevel.SetActive(true);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void backToKategoriMenu()
    {   
        kategoriMenu.SetActive(true);
        omnivoraLevel.SetActive(false);
        herbivoraLevel.SetActive(false);
        karnivoraLevel.SetActive(false);
        audioManager.instance.PlaySFX(audioManager.instance.click);
    }

    public void muteBtn()
    {
        isSFXMuted = !isSFXMuted;
        audioManager.instance.MuteSFX(isSFXMuted);
        isMusicMuted = !isMusicMuted;
        audioManager.instance.MuteMusic(isMusicMuted);
        Debug.Log("mute");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
