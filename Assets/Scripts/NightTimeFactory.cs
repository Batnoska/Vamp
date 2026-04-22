using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/NightFactory")]
public class NightTimeFactory : EnemyFactorySO
{
    public override GameObject CreateGoblin()
    {
        GameObject enemy = Instantiate(goblinPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 3.5f, damage: 6f, health: 5f);

        return enemy;
    }

    public override GameObject CreateOrc()
    {
        GameObject enemy = Instantiate(orcPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 2.2f, damage: 8f, health: 9f);

        return enemy;
    }

    public override GameObject CreateSkeleton()
    {
        GameObject enemy = Instantiate(skeletonPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 4f, damage: 4f, health: 3f);

        return enemy;
    }
}
