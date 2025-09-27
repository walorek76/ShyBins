using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private Scrollbar volumeSlider;

    [Header("Audio")]
    [SerializeField] private AudioSource musicSource;

    public static GameManager instance;

    private bool isPaused = false;
    private bool isAudioOn = true;

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
            return;
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (pauseMenuCanvas != null) pauseMenuCanvas.SetActive(false);

        if (musicSource != null) musicSource.volume = 0.1f;

        if (volumeSlider != null)
        {
            volumeSlider.value = musicSource != null ? musicSource.volume : 0.5f;
            volumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene("MainMenu"); 
    }

    public void ChangeMusicVolume(float newVolume)
    {
        if (musicSource != null)
            musicSource.volume = newVolume;
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
