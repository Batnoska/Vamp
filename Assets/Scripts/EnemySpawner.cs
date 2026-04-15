using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyFactorySO[] enemyFactories;

    [SerializeField] Transform player;

    [SerializeField] float spawnInterval = 2f;

    [SerializeField] float spawnDistance = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        EnemyFactorySO factory = GetRandomFactory();

        GameObject enemy = factory.CreateEnemy();

        enemy.transform.position = GetSpawnPosition();
    }

    EnemyFactorySO GetRandomFactory()
    {
        int index = Random.Range(0, enemyFactories.Length);

        return enemyFactories[index];
    }

    Vector3 GetSpawnPosition()
    {
        Vector2 offset = Random.insideUnitCircle.normalized * spawnDistance;

        return player.position + (Vector3)offset;
    }
}
