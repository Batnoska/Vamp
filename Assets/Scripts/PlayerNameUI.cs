using TMPro;
using UnityEngine;

public class PlayerNameUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public void SavePlayerName()
    {
        string playerName = inputField.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Unknown";
        }
        
        HighScoreManager.Instance.SetPlayerName(playerName);
    }
}
