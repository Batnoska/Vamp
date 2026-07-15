using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public ScoreSaveData Data;
    
    private const int MAX_SCORES = 10;

    private string SavePath => Path.Combine(Application.persistentDataPath, "highscores.json");

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

    public void SetPlayerName(string playerName)
    {
        Data.playerName = playerName;
        
        SaveScores();
    }

    public string GetPlayerName()
    {
        return Data.playerName;
    }

    public void AddScore(int score)
    {
        Data.scores.Add(new ScoreEntry(Data.playerName, score));

        Data.scores.Sort((a, b) => b.score.CompareTo(a.score));

        if (Data.scores.Count > MAX_SCORES)
        {
            Data.scores.RemoveRange(MAX_SCORES, Data.scores.Count - MAX_SCORES);
        }

        SaveScores();
    }

    void SaveScores()
    {
        string json = JsonUtility.ToJson(Data, true);
        
        File.WriteAllText(SavePath, json);
    }

    void LoadScores()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);

            Data = JsonUtility.FromJson<ScoreSaveData>(json);
        }
        else
        {
            Data = new ScoreSaveData();
            
            SaveScores();
        }
    }
}
