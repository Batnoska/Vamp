using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    
    public event Action<float> OnTimeChanged;
    public event Action OnNightStarted;

    private EnemySpawner enemySpawner;

    float timer;

    bool nightTriggered = false;
    bool victoryTriggered = false;

    private void Awake()
    {
        Instance = this;
        
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        
        Debug.Log(timer);

        OnTimeChanged?.Invoke(timer);

        CheckNightTrigger();
        CheckVictoryTrigger();
    }
    
    void CheckNightTrigger()
    {
        if (nightTriggered) return;

        if (timer >= 90f)
        {
            nightTriggered = true;

            Debug.Log("Night mode activated");

            OnNightStarted?.Invoke();
        }
    }

    void CheckVictoryTrigger()
    {
        if (victoryTriggered) return;

        if (timer >= 180f)
        {
            victoryTriggered = true;

            Debug.Log("Victory condition reached");

            enemySpawner.gameObject.SetActive(false);

            SceneManager.LoadScene("Victory");
        }
    }
}
