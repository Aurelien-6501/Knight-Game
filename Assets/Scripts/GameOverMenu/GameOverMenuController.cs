using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}