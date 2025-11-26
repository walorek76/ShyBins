using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircleScript : MonoBehaviour
{
    public float speed = 360f; 

    void Update()
    {
        transform.Rotate(0f ,0f,-speed * Time.deltaTime);
    }
}

