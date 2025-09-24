using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ChangeSprite : MonoBehaviour
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
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = upSprite;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = downSprite;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = rightSprite;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = leftSprite;
        }
    }
}
