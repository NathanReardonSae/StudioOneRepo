using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 10; // The variable that determines the amount of damage the spike will do to the player.

    private void OnTriggerEnter2D(Collider2D collision) // a function that handles the collision of the player and the spike.
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log(" COLLISION");
            }
        }
    }
}

