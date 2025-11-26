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

    [Header("Players")]
    public PlayerHealth player1;
    public PlayerHealth player2;

    [Header("UI")]
    public GameObject gameOverPanel;
    public Text winnerText;

    public static GameManager instance;
    bool gameOver = false;

    private bool isPaused = false;
    private bool isAudioOn = true;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
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
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);

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
        SceneManager.LoadScene("MainMenu"); 
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

    void ShowGameOver(string message)
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        winnerText.text = message;
        Time.timeScale = 0f; 
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (gameOver) return;

        if (player1.currentHealth <= 0)
        {
            ShowGameOver("Yellow shybin wins");
        }

        if (player2.currentHealth <= 0)
        {
            ShowGameOver("Green Shybin wins");
        }
    }
}
