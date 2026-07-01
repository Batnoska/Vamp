using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/DayFactory")]
public class DayTimeFactory : EnemyFactorySO
{
    public override GameObject SpawnGoblin()
    {
        GameObject enemy =
            PoolManage.Instance.Get(goblinPrefab);

        enemy.GetComponent<Enemy>()
            .SetOrigin(goblinPrefab);

        return enemy;
    }
    
    public override GameObject SpawnOrc()
    {
        GameObject enemy =
            PoolManage.Instance.Get(orcPrefab);

        enemy.GetComponent<Enemy>().SetOrigin(orcPrefab);

        return enemy;
    }
    
    public override GameObject SpawnSkeleton()
    {
        GameObject enemy =
            PoolManage.Instance.Get(skeletonPrefab);

        enemy.GetComponent<Enemy>()
            .SetOrigin(skeletonPrefab);

        return enemy;
    }
}
