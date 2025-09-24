using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1ChangeSprite : MonoBehaviour
{
    public Sprite downSprite; 
    public Sprite upSprite;      
    public Sprite leftSprite;      
    public Sprite rightSprite;      

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = downSprite;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = upSprite;
        }
        if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = downSprite;
        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = rightSprite;
        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = leftSprite;
        }
    }
}
