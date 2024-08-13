using UnityEngine;
using System.Collections;

public class GameStartPopup : MonoBehaviour
{
    public GameObject popupPanel; // Reference to the popup panel
    public float displayDuration = 5f; // Duration to show the popup in seconds

    void Start()
    {
        // Show the popup at the start of the game and pause the game
        ShowPopup();
        
        // Start a coroutine to hide the popup after the display duration
        StartCoroutine(HidePopupAfterDelay(displayDuration));
    }

    void ShowPopup()
    {
        popupPanel.SetActive(true); // Activate the popup panel
        Time.timeScale = 0f; // Pause the game
    }

    void HidePopup()
    {
        popupPanel.SetActive(false); // Deactivate the popup panel
        Time.timeScale = 1f; // Resume the game
    }

    IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified duration, ignoring time scale
        HidePopup(); // Hide the popup and resume the game
    }
}


