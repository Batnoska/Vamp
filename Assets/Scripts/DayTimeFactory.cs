using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/DayFactory")]
public class DayTimeFactory : EnemyFactorySO
{
    public override GameObject CreateGoblin()
    {
        GameObject enemy = Instantiate(goblinPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 2f, damage: 5f);

        return enemy;
    }

    public override GameObject CreateOrc()
    {
        GameObject enemy = Instantiate(orcPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 1.2f, damage: 10f);

        return enemy;
    }

    public override GameObject CreateSkeleton()
    {
        GameObject enemy = Instantiate(skeletonPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 2.5f, damage: 4f);

        return enemy;
    }
}
