using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStart : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    void Awake()
    {
        if (GameData.Instance.musicBool)
        {
            musicSource.UnPause();
        }
        else
        {
            musicSource.Pause();
        }
        if (GameData.Instance.effectsBool)
        {
            // audioSource.Pause();
        }
        if (musicSource != null) musicSource.volume = GameData.Instance.volumeMusic; 
    }

    
}
