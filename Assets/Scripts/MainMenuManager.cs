using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject settingsMenuCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private Scrollbar volumeSlider;
    [SerializeField] private Toggle musicToggle;

    [Header("Audio")]
    [SerializeField] private AudioSource musicSource;
    private bool isPaused = false;
    private bool isAudioOn = false;
    void Start()
    {
        settingsMenuCanvas.SetActive(true);
        isAudioOn = GameData.Instance.musicBool;
        musicToggle.isOn = GameData.Instance.musicBool;
        

        if (settingsMenuCanvas != null) settingsMenuCanvas.SetActive(false);

        if (musicSource != null) musicSource.volume = GameData.Instance.volumeMusic;

        if (volumeSlider != null)
        {
            volumeSlider.value = musicSource != null ? musicSource.volume : 0.5f;
            volumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        }
        if (GameData.Instance.musicBool)
        {
            musicSource.UnPause();
        }
        else
        {
            musicSource.Pause();
        }

    }
    
    
    public void PauseGame()
    {
        isPaused = !isPaused;

        if (settingsMenuCanvas != null)
            settingsMenuCanvas.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
    public void ChangeMusicVolume(float newVolume)
    {
        if (musicSource != null)
            musicSource.volume = newVolume;
        GameData.Instance.volumeMusic = newVolume;
    }

    public void ToggleMusicVolume()
    {
        if (musicSource == null) return;

        if (isAudioOn)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }

        isAudioOn = !isAudioOn;
        GameData.Instance.musicBool = !GameData.Instance.musicBool;
    }
    public void OpenSettingsMenu()
    {
        PauseGame();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
