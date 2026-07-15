using UnityEngine;


[CreateAssetMenu(menuName = "Factories/Enemies/EnemyFactory")]
public class EnemyFactorySO : ScriptableObject
{
    [SerializeField] protected GameObject goblinPrefab;
    [SerializeField] protected GameObject orcPrefab;
    [SerializeField] protected GameObject skeletonPrefab;

    public GameObject SpawnGoblin()
    {
        return SpawnFromPrefab(goblinPrefab);
    }

    public GameObject SpawnOrc()
    {
        return SpawnFromPrefab(orcPrefab);
    }

    public GameObject SpawnSkeleton()
    {
        return SpawnFromPrefab(skeletonPrefab);
    }

    private GameObject SpawnFromPrefab(GameObject prefab)
    {
        GameObject enemy = PoolManage.Instance.Get(prefab);

        enemy.GetComponent<Enemy>().SetOrigin(prefab);

        return enemy;
    }
}
