using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ChangeSprite : MonoBehaviour
{
    public Animator animator;
    public Sprite downSprite, upSprite, leftSprite, rightSprite, LDSprite, RDSprite, RTSprite, LTSprite; 

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = downSprite;
    }

    void Update()
    {
        // diagonal movement
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("GoingDown", true);
            animator.SetBool("GoingUp", false);
            animator.SetBool("GoingLeft", true);
            animator.SetBool("GoingRight", false);
            
            return;
        } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            
            animator.SetBool("GoingDown", true);
            animator.SetBool("GoingUp", false);
            animator.SetBool("GoingLeft", false);
            animator.SetBool("GoingRight", true);
            return;
        } else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("GoingDown", false);
            animator.SetBool("GoingUp", true);
            animator.SetBool("GoingLeft", false);
            animator.SetBool("GoingRight", true);
            return;
        } else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            
            animator.SetBool("GoingDown", false);
            animator.SetBool("GoingUp", true);
            animator.SetBool("GoingLeft", true);
            animator.SetBool("GoingRight", false);
            return;
        }

        // linear movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("GoingDown", false);
            animator.SetBool("GoingUp", true);
            animator.SetBool("GoingLeft", false);
            animator.SetBool("GoingRight", false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("GoingDown", true);
            animator.SetBool("GoingUp", false);
            animator.SetBool("GoingLeft", false);
            animator.SetBool("GoingRight", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
           animator.SetBool("GoingDown", false);
            animator.SetBool("GoingUp", false);
            animator.SetBool("GoingLeft", false);
            animator.SetBool("GoingRight", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("GoingDown", false);
            animator.SetBool("GoingUp", false);
            animator.SetBool("GoingLeft", true);
            animator.SetBool("GoingRight", false);
        }
    }

}
