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
    [SerializeField] private GameObject _gamePauseCanvas;
    [SerializeField] private GameObject _audioSource;
    public static GameManager instance;
    private bool activePause = false;
    private bool activeAudio = true;
    private void Start()
    {
        _gamePauseCanvas.SetActive(false);
        _audioSource.GetComponent<AudioSource>().volume = 0.1f;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        if (activePause)
        {
            _gamePauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            activePause = !activePause;
        }
        else
        {
            _gamePauseCanvas.SetActive(false);
            Time.timeScale = 1f;
            activePause = !activePause;
        }
    }
    public void ExitToDesktop()
    {
        Application.Quit();
    }
    public void ExitToMainMenu()
    {

    }
    // public void ChangedVolume(){
    //      float AudioVolume = _gamePauseCanvas.GetComponent<Scrollbar>().value;
    //      _audioSource.GetComponent<AudioSource>().volume = AudioVolume;
    // }
    public void ToggleVolume() {
        if (activeAudio)
        {
            _audioSource.GetComponent<AudioSource>().Pause();
            activeAudio = !activeAudio;
        }
        else
        { 
            _audioSource.GetComponent<AudioSource>().UnPause();
            activeAudio = !activeAudio;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
}
