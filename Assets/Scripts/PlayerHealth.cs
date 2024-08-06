using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public string gameOverScreen = "gameOverScreen"; // Calls the game over screen when the player died.
    public float deathYPosition = -10f; // Death Parameters
    public AudioSource hurtSound; // Add this line for the hurt sound effect

    // Public field for the blood splatter prefab
    public GameObject bloodSplatterPrefab;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
    }

    void Update()
    {
        // Check if player falls below deathYPosition
        if (transform.position.y < deathYPosition)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return; // Don't take damage if player is already dead
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (hurtSound != null) // Play the hurt sound if assigned
        {
            hurtSound.Play();
        }

        // Instantiate blood splatter effect
        if (bloodSplatterPrefab != null)
        {
            Instantiate(bloodSplatterPrefab, transform.position, Quaternion.identity);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die() // Make sure Die() is public so it can be accessed from other scripts
    {
        Debug.Log("Player Died");

        // Load the game over scene
        SceneManager.LoadScene(3);
    }
}



