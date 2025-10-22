using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float timer = 0f;
    private bool isDamaged = false;


    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentHealth = maxHealth;
        originalColor = spriteRenderer.color; 
    }

    void Update()
    {
        
        if (isDamaged)
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                spriteRenderer.color = originalColor;
                timer = 0f;
                isDamaged = false; 
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        spriteRenderer.color = Color.red;
        isDamaged = true; 

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
