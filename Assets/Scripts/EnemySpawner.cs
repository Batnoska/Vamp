using System;
using UnityEngine;
using UnityEngine.Pool;
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

        GameObject prefab;
        GameObject enemy;

        switch (random)
        {
            case 0:
                prefab = currentFactory.GetGoblinPrefab();
                enemy = PoolManage.Instance.Get(prefab);
                currentFactory.ConfigureGoblin(enemy);
                break;
            case 1:
                prefab = currentFactory.GetOrcPrefab();
                enemy = PoolManage.Instance.Get(prefab);
                currentFactory.ConfigureOrc(enemy);
                break;

            default:
                prefab = currentFactory.GetSkeletonPrefab();
                enemy = PoolManage.Instance.Get(prefab);
                currentFactory.ConfigureSkeleton(enemy);
                break;
        }

        enemy.transform.position = GetSpawnPosition();

        Enemy e = enemy.GetComponent<Enemy>();
        e.SetTarget(player);
        e.SetOrigin(prefab);

        // GameObject enemy = random switch
        // {
        //     0 => currentFactory.CreateGoblin(),
        //     1 => currentFactory.CreateOrc(),
        //     _ => currentFactory.CreateSkeleton()
        // };
        //
        // enemy.transform.position = GetSpawnPosition();
        // enemy.GetComponent<Enemy>().SetTarget(player);
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
