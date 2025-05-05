using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public static void AddScore(int value)
    {
        score += value;
        if (Instance != null)
            Instance.UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
