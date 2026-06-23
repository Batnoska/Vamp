using System;
using UnityEngine;

public class GameScoreTracker : MonoBehaviour
{
    [SerializeField] private EnemyDeathEventChannelSO deathChannel;

    private int kills;

    private void OnEnable()
    {
        deathChannel.OnEventRaised += OnEnemyKilled;
    }

    private void OnDisable()
    {
        deathChannel.OnEventRaised -= OnEnemyKilled;
    }

    void OnEnemyKilled(Enemy enemy)
    {
        kills++;
    }

    public int CurrentScore => kills;
}
