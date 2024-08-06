using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int points = 1; // Points awarded for picking up this item

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pick-up detected by player!");

            // Check if GameManager.Instance is null before accessing it
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CollectPickup(points);
                Debug.Log("Pickup collected. Points added: " + points);
            }
            else
            {
                Debug.LogError("GameManager instance is not found!");
            }

            Destroy(gameObject); // Destroy this pick-up GameObject
        }
    }
}




