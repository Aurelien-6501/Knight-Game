using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UIManager UIManager { get; private set; }
    public AudioManager AudioManager { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        UIManager = GetComponent<UIManager>();
        AudioManager = GetComponent<AudioManager>();
    }


    public void StartGame()
    {
        UIManager.StartGame();
        AudioManager.StartGame();
    }
    
    public void StopGame()
    {
        UIManager.StopGame();
        AudioManager.StopGame();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverMenu"); 
    }
    
    public void WinGame()
    {
        SceneManager.LoadScene("WinMenu"); 
    }
}