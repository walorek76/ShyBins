using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1ChangeSprite : MonoBehaviour
{
    public Sprite downSprite, upSprite, leftSprite, rightSprite, LDSprite, RDSprite, RTSprite, LTSprite; 
    //public Sprite upSprite;      
    //public Sprite leftSprite;      
    //public Sprite rightSprite;
    //public Sprite LDSprite;
    //public Sprite RDSprite;
    //public Sprite RTSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = downSprite;
    }

    void Update()
    {
        // diagonal movement
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = LDSprite;
            return;
        } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = RDSprite;
            return;
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = RTSprite;
            return;
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = LTSprite;
            return;
        }

        // linear movement
        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = downSprite;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = leftSprite;
        }
    }

}
