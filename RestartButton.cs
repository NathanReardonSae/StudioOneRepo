using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public string firstLevelName = "Level1"; // Replace with your first level scene name

    public void RestartGame()
    {
        SceneManager.LoadScene(Level01);
    }
}

