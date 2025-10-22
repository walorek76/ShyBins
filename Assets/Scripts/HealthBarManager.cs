using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth1;
    [SerializeField] PlayerHealth playerHealth2;

    [SerializeField] Text textHealth1;
    [SerializeField] Text textHealth2;

    void Start()
    {
        playerHealth1.currentHealth = playerHealth1.maxHealth;
        playerHealth2.currentHealth = playerHealth2.maxHealth;

        UpdateHealthText();
    }

    void Update()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        textHealth1.text = "Health: " + playerHealth1.currentHealth.ToString();
        textHealth2.text = "Health: " + playerHealth2.currentHealth.ToString();
    }
}
