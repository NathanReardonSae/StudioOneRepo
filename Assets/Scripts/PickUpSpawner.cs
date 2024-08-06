using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // Reference to the pickup prefab

    void Start()
    {
        SpawnPickups();
    }

    void SpawnPickups()
    {
        if (pickupPrefab == null)
        {
            Debug.LogError("Pickup prefab is not assigned!");
            return;
        }

        // Example positions for spawning pickups
        Vector3[] spawnPositions = {
            new Vector3(0, 0, 0),
            new Vector3(2, 2, 0),
            new Vector3(-2, -2, 0)
        };

        foreach (Vector3 position in spawnPositions)
        {
            Instantiate(pickupPrefab, position, Quaternion.identity);
            Debug.Log("Spawned pick-up at " + position);
        }
    }
}




