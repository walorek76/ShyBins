using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public bool musicBool = true;
    public bool effectsBool = true;
    public float volumeMusic = 0.1f;
    public float volumeEffects = 0.1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
