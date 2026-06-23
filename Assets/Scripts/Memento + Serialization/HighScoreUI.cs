using System;
using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scoreTexts;

    private void Start()
    {
        var scores = HighScoreManager.Instance.Scores;

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scores.Count)
            {
                scoreTexts[i].text = $"{i + 1}. {scores[i].playerName} - {scores[i].score}";
            }
            else
            {
                scoreTexts[i].text = $"{i + 1}. ---";
            }
        }
    }
}
