using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // the int variable that contains the max health the player can have.
    public int currentHealth; // A variable that contains and displays the players current health.
    public HealthBar healthBar;
    public string gameOverScreen = "GameOver"; // Referencing to the Game Over Scene in the game.

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died");

        // Load the game over scene
        SceneManager.LoadScene(gameOverScreen);
    }
}


