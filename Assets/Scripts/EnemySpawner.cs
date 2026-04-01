using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject goblinPrefab;
    public GameObject orcPrefab;
    public GameObject skeletonPrefab;

    public Transform player;

    public float spawnInterval = 2f;

    public float spawnDistance = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        EnemyType type = EnemyFactory.GetRandomType();

        GameObject prefab = GetPrefab(type);

        GameObject enemy = EnemyFactory.CreateEnemy(type, prefab);

        enemy.transform.position = GetSpawnPosition();
    }

    GameObject GetPrefab(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Goblin:
                return goblinPrefab;
            
            case EnemyType.Orc:
                return orcPrefab;
            
            case EnemyType.Skeleton:
                return skeletonPrefab;
        }

        return null;
    }

    Vector3 GetSpawnPosition()
    {
        Vector2 offset = Random.insideUnitCircle.normalized * spawnDistance;

        return player.position + (Vector3)offset;
    }
}
