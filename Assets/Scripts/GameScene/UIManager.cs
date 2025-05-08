using UnityEngine;

public class UIManager : MonoBehaviour
{

    // public TMPro.TextMeshProUGUI score;
    // public TMPro.TextMeshProUGUI bestScore;
    // public TMPro.TextMeshProUGUI timeText;
    public GameObject startButton;

    private GameManager _gm;


    private void Awake()
    {
        _gm = GameManager.Instance;
    }


    private void Update()
    {
        // score.text = $"Score: {_gm.ScoreManager.Score}";
        // bestScore.text = $"Best: {_gm.ScoreManager.BestScore}";
        // timeText.text = $"Time: {_gm.TimeManager.Remaining:F0}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
    }

    public void StopGame()
    {
        startButton.SetActive(true);
    }

}
