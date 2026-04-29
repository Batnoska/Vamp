using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/DayFactory")]
public class DayTimeFactory : EnemyFactorySO
{
    public override GameObject CreateGoblin()
    {
        GameObject enemy = Instantiate(goblinPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 2f, damage: 4f, health: 3f);

        return enemy;
    }

    public override void ConfigureGoblin(GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.SetStats(2f, 4f, 3f);
    }
    
    public override GameObject CreateOrc()
    {
        GameObject enemy = Instantiate(orcPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 1.2f, damage: 7f, health: 6f);

        return enemy;
    }
    
    public override void ConfigureOrc(GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.SetStats(1.2f, 7f, 6f);
    }

    public override GameObject CreateSkeleton()
    {
        GameObject enemy = Instantiate(skeletonPrefab);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        enemyComponent.SetStats(speed: 2.5f, damage: 2f, health: 2f);

        return enemy;
    }
    
    public override void ConfigureSkeleton(GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.SetStats(2.5f, 2f, 2f);
    }
}
