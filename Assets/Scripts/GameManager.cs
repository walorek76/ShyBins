using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        _gamePauseCanvas.SetActive(false);
    }
    public static GameManager instance;
    private bool activePause = false;
    [SerializeField] private GameObject _gamePauseCanvas;
    
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
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
