using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBarScript : MonoBehaviour
{
    public Image fillImage;    
    public float speed = 0.3f;  

    private float progress = 0f;

    void Update()
    {
        if (progress < 1f)
        {
            progress += speed * Time.deltaTime;
            fillImage.fillAmount = progress;
        }
    }
}

