using System;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public List<ScoreEntry> Scores = new List<ScoreEntry>();
    
    private const int MAX_SCORES = 10;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);

        LoadScores();
    }

    public void AddScore(int score)
    {
        string playerName =
            PlayerPrefs.GetString(
                "PLAYER_NAME",
                "Unknown");

        Scores.Add(
            new ScoreEntry(playerName, score));

        Scores.Sort(
            (a, b) => b.score.CompareTo(a.score));

        if (Scores.Count > MAX_SCORES)
        {
            Scores.RemoveRange(
                MAX_SCORES,
                Scores.Count - MAX_SCORES);
        }

        SaveScores();
    }

    void SaveScores()
    {
        PlayerPrefs.SetInt(
            "ScoreCount",
            Scores.Count);

        for (int i = 0; i < Scores.Count; i++)
        {
            PlayerPrefs.SetString(
                $"PlayerName_{i}",
                Scores[i].playerName);

            PlayerPrefs.SetInt(
                $"PlayerScore_{i}",
                Scores[i].score);
        }

        PlayerPrefs.Save();
    }

    void LoadScores()
    {
        Scores.Clear();

        int count =
            PlayerPrefs.GetInt(
                "ScoreCount",
                0);

        for (int i = 0; i < count; i++)
        {
            string playerName =
                PlayerPrefs.GetString(
                    $"PlayerName_{i}");

            int score =
                PlayerPrefs.GetInt(
                    $"PlayerScore_{i}");

            Scores.Add(
                new ScoreEntry(
                    playerName,
                    score));
        }
    }
}
