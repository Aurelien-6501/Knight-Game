using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuController : MonoBehaviour
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