using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public int totalWaves = 4;
    private int currentWave = 0;
    public float timeBetweenWaves = 5f;

    public SpawnerManager spawnerManager;
    public TMP_Text waveText;
    private bool gameEnded = false;
    private bool waitingForNextWave = false;

    void Start()
    {
        StartNextWave();
    }

    void Update()
    {
        if (!gameEnded && GameObject.FindGameObjectsWithTag("skeleton").Length == 0)
        {
            if (!waitingForNextWave)
            {
                waitingForNextWave = true; 
                if (currentWave < totalWaves)
                {
                    Invoke(nameof(StartNextWave), timeBetweenWaves);
                }
                else
                {
                    GameManager.Instance.WinGame(); 
                }
            }
        }
    }

    void StartNextWave()
    {
        currentWave++;
        waitingForNextWave = false; 
        spawnerManager.SpawnWave(currentWave);
        UpdateWaveUI();
    }

    void UpdateWaveUI()
    {
        if (waveText != null)
        {
            waveText.text = $"Wave {currentWave}/{totalWaves}";
        }
    }
}