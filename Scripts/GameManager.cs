using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text pickupCountText; // UI text to display pickup count
    public GameObject popupPanel; // Reference to the popup panel
    public Button closeButton; // Reference to the close button

    private int pickupCount;
    private bool hasGameStarted = false; // Track if the game has started

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

    private void Start()
    {
        InitializeUI();
        if (!hasGameStarted)
        {
            ShowPopup();
            hasGameStarted = true;
        }
    }

    private void InitializeUI()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false); // Ensure popup is initially hidden
        }
        else
        {
            Debug.LogWarning("PopupPanel is not assigned.");
        }

        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners(); // Clear existing listeners
            closeButton.onClick.AddListener(ClosePopup); // Add listener
            Debug.Log("Close button listener added.");
        }
        else
        {
            Debug.LogWarning("CloseButton is not assigned.");
        }
    }

    private void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            Time.timeScale = 0; // Pause the game
            Debug.Log("Popup shown.");
        }
    }

    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
            Time.timeScale = 1; // Resume the game
            Debug.Log("Popup closed.");
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

    public void OnPlayerDeath()
    {
        Time.timeScale = 0; // Pause the game
        ShowPopup(); // Show popup on game over
    }

    public void RetryLevel()
    {
        // Ensure the game is running normally
        Time.timeScale = 1; 
        hasGameStarted = false; // Reset the flag so the popup can appear on the next start
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
        InitializeUI(); // Reinitialize UI components when a new scene is loaded

        // Ensure the popup is hidden after the scene loads
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }
}
















