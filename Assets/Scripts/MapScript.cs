using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour
{
    
    public void LoadMap1()
    {        
        SceneManager.LoadScene("Sala1");
    }

    public void LoadMap2()
    {
        SceneManager.LoadScene("SalaAula");
    }

    public void LoadMap3()
    {
        SceneManager.LoadScene("Sala6");
    }

    public void LoadMap4()
    {
        SceneManager.LoadScene("");
    }
}
