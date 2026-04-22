using System;
using TMPro;
using UnityEngine;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;
    private void OnEnable()
    {

        GameTimer.Instance.OnTimeChanged += UpdateTimer;
    }

    private void OnDisable()
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
