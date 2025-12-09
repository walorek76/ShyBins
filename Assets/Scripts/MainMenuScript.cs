using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Canvas canvas1;
    
    
    void Start()
    {
        canvas1.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void LoadGameScene()
    {
      canvas1.gameObject.SetActive(true);
    }
}
