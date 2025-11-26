using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color damageColor = new Color(0.9686f, 0.5608f, 0.5608f);
    private float timer = 0f;
    private bool isDamaged = false;


    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color; 
    }

    void Update()
    {
        
        if (isDamaged)
        {
            timer += Time.deltaTime;

            if (timer >= 0.1f)
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
        spriteRenderer.color = damageColor;
        isDamaged = true; 

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
