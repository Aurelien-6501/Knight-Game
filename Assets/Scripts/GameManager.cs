using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UIManager UIManager { get; private set; }
    public AudioManager AudioManager { get; private set; }

public SpawnerManager SpawnerManager;
    // public ScoreManager ScoreManager { get; private set; }
    // public TimeManager TimeManager { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        UIManager = GetComponent<UIManager>();
        AudioManager = GetComponent<AudioManager>();
        // ScoreManager = GetComponent<ScoreManager>();
        // TimeManager = GetComponent<TimeManager>();
    }

    // --

    public void StartGame()
    {
        // TimeManager.OnTimeUp += TimeUpHandler;

        UIManager.StartGame();
        AudioManager.StartGame();
        SpawnerManager.StartSpawning();
        // ScoreManager.StartGame();
        // TimeManager.StartGame();
    }
    
    public void StopGame()
    {
        // TimeManager.OnTimeUp -= TimeUpHandler;

        UIManager.StopGame();
        AudioManager.StopGame();
        SpawnerManager.StopSpawning();
        // ScoreManager.StopGame();
        // TimeManager.StopGame();
    }

    private void TimeUpHandler()
    {
        StopGame();
    }
}