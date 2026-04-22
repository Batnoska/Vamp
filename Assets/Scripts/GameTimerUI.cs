using System;
using TMPro;
using UnityEngine;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;

    private void Start()
    {
        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.OnTimeChanged += UpdateTimer;
        }
    }

    private void OnDestroy()
    {
        GameTimer.Instance.OnTimeChanged -= UpdateTimer;
    }

    void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
