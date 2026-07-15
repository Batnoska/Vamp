using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreSaveData
{
    public string playerName;
    
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}
