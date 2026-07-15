using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyFactorySO currentFactory;

    [SerializeField] private EnemyDeathEventChannelSO enemyDeathChannel;

    [SerializeField] Transform player;

    [SerializeField] float spawnInterval = 2f;

    [SerializeField] float spawnDistance = 4f;

    [SerializeField] private int maxEnemies = 10;

    private int currentEnemies;

    private void OnEnable()
    {
        enemyDeathChannel.OnEventRaised += OnEnemyDeath;
    }

    private void OnDisable()
    {
        enemyDeathChannel.OnEventRaised -= OnEnemyDeath;
    }

    private void Start()
    {
        
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies)
            return;

        GameObject enemy = Random.Range(0, 3) switch
        {
            0 => currentFactory.SpawnGoblin(),
            1 => currentFactory.SpawnOrc(),
            _ => currentFactory.SpawnSkeleton()
        };

        enemy.transform.position =
            GetSpawnPosition();

        enemy.GetComponent<Enemy>()
            .SetTarget(player);

        currentEnemies++;
    }
    

    Vector3 GetSpawnPosition()
    {
        Vector2 offset = Random.insideUnitCircle.normalized * spawnDistance;

        return player.position + (Vector3)offset;
    }

    public void SetFactory(EnemyFactorySO newFactory)
    {
        currentFactory = newFactory;
        
        Debug.Log("Cycle");
    }

    void OnEnemyDeath(Enemy enemy)
    {
        currentEnemies--;
        
        Debug.Log("Enemy died. Alive: " + currentEnemies);
    }
}
