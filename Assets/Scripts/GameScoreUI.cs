using TMPro;
using UnityEngine;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private GameScoreTracker scoreTracker;

    private void Start()
    {
        scoreTracker =
            FindFirstObjectByType<GameScoreTracker>();

        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = $"{scoreTracker.CurrentScore}";
    }
}
