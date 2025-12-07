using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using TMPro;


public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private Scrollbar volumeSlider;
    [SerializeField] private Scrollbar volumeEffects;


    [Header("Audio")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource Gun1;
    [SerializeField] private AudioSource Gun2;

    [Header("Players")]
    public PlayerHealth player1;
    public PlayerHealth player2;
    public Sprite player1Sprite;
    public Sprite player2Sprite;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TMP_Text winnerText;
    public UnityEngine.UI.Image winnerImage;

    public static GameManager instance;
    bool gameOver = false;

    private bool isPaused = false;
    private bool isAudioOn = true;
    private bool isEffectsOn = true;


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

        if (musicSource != null) musicSource.volume = 0.5f;

        if (volumeSlider != null)
        {
            volumeSlider.value = musicSource != null ? musicSource.volume : 0.5f;
            volumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        }
        
        if (isAudioOn)
        {
            musicSource.Play();
        }
           
        if (volumeEffects != null)
        {
                volumeEffects.value = Gun1 != null ? Gun1.volume : 0.5f;
                volumeEffects.value = Gun2 != null ? Gun2.volume : 0.5f;
                volumeEffects.onValueChanged.AddListener(ChangeEffectsVolume);
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
    public void ChangeEffectsVolume(float newVolume)
    {
        Gun1.volume = newVolume;
        Gun2.volume = newVolume;
    }

    public void ToggleEffectsVolume()
{
    

    if (isEffectsOn)
    {
        Gun1.volume = 0f;
        Gun2.volume = 0f;
    }
    else
    {
        Gun1.volume = volumeEffects != null ? volumeEffects.value : 0.5f;
        Gun2.volume = volumeEffects != null ? volumeEffects.value : 0.5f;
    }

    isEffectsOn = !isEffectsOn;
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

    void ShowGameOver(string message, Sprite winnerSprite)
    {
        gameOver = true;
        gameOverPanel.SetActive(true);

        winnerText.text = message;
        winnerImage.sprite = winnerSprite;

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

        if (player2.currentHealth <= 0)
        {
            ShowGameOver("Green Shybin wins", player1Sprite);
        }

        if (player1.currentHealth <= 0)
        {
            ShowGameOver("Yellow shybin wins", player2Sprite);
        }
    }
}
