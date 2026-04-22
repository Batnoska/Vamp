using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyFactorySO currentFactory;

    [SerializeField] Transform player;

    [SerializeField] float spawnInterval = 2f;

    [SerializeField] float spawnDistance = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, 3);

        GameObject enemy = random switch
        {
            0 => currentFactory.CreateGoblin(),
            1 => currentFactory.CreateOrc(),
            _ => currentFactory.CreateSkeleton()
        };

        enemy.transform.position = GetSpawnPosition();
        enemy.GetComponent<Enemy>().SetTarget(player);
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
}
