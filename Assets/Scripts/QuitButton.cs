using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Method to be called when the Quit button is pressed
    public void OnQuitButtonPressed()
    {
        // Quit the application
        QuitApplication();
    }

    // Method to handle quitting the application
    private void QuitApplication()
    {
        // Check if we are running in the Unity Editor
        if (Application.isEditor)
        {
            // If running in the Unity Editor, stop play mode
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            // If running in a standalone build, quit the application
            Application.Quit();
        }
    }
}



