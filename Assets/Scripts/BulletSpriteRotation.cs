using UnityEngine;

public class RotateSpriteEveryTwoSeconds : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

       
        InvokeRepeating(nameof(RotateSprite), 2f, 2f);
    }

    void RotateSprite()
    {
        
        transform.Rotate(0f, 0f, 160f);
    }
}
