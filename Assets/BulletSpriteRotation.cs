using UnityEngine;

public class RotateSpriteContinuously2 : MonoBehaviour
{
    public float rotationSpeed = 360f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
