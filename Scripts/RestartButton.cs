using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public string firstLevelName = "Level01"; 
    
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level01"); 
    }
}

