using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Text pickupCountText; // UI text to display pickup count

    private int pickupCount;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager instance set.");
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager instance detected. Destroying this one.");
            Destroy(gameObject);
        }
    }

    public void CollectPickup(int points)
    {
        pickupCount += points;
        UpdatePickupCountUI();
    }

    private void UpdatePickupCountUI()
    {
        if (pickupCountText != null)
        {
            pickupCountText.text = "Pickups: " + pickupCount;
        }
        else
        {
            Debug.LogWarning("PickupCountText is not assigned.");
        }
    }
}




