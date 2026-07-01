using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private PlayerNameUI playerName;
    
    public void Play()
    {
        playerName.SavePlayerName();
        
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
