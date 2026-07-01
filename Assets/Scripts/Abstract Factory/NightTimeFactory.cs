using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/NightFactory")]
public class NightTimeFactory : EnemyFactorySO
{
    public override GameObject SpawnGoblin()
    {
        GameObject enemy =
            PoolManage.Instance.Get(goblinPrefab);

        Enemy e =
            enemy.GetComponent<Enemy>();

        e.SetOrigin(goblinPrefab);

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

        Enemy e =
            enemy.GetComponent<Enemy>();

        e.SetOrigin(skeletonPrefab);

        return enemy;
    }
}
