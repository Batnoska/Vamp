using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/NightFactory")]
public class NightTimeFactory : EnemyFactorySO
{
    public override GameObject CreateGoblin()
    {
        GameObject enemy = Instantiate(goblinPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 3.5f, damage: 8f);

        return enemy;
    }

    public override GameObject CreateOrc()
    {
        GameObject enemy = Instantiate(orcPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 2.2f, damage: 15f);

        return enemy;
    }

    public override GameObject CreateSkeleton()
    {
        GameObject enemy = Instantiate(skeletonPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 4f, damage: 7f);

        return enemy;
    }
}
