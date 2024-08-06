using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth; // A public variable that contains the players health.
    public Slider healthSlider; // A public variable that contains the players health.
    public Text healthText; // A variable that will contain the text of the health bar.

    void Start()
    {
        if (playerHealth != null && healthSlider != null)
        {
            SetMaxHealth(playerHealth.maxHealth);
        }
    }

    void Update()
    {
        if (playerHealth != null && healthSlider != null)
        {
            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        float sliderValue = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        healthSlider.value = Mathf.Clamp01(sliderValue);
        healthText.text = "Health: " + playerHealth.currentHealth.ToString();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        healthText.text = "Health: " + maxHealth.ToString();
    }

    public void SetHealth(int currentHealth)
    {
        playerHealth.currentHealth = currentHealth;
        UpdateHealthBar();
    }
}

