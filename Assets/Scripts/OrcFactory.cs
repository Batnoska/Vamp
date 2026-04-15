using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/OrcFactory")]
public class OrcFactory : EnemyFactorySO
{
    [SerializeField] GameObject prefab;
    
    public override EnemyType Type => EnemyType.Orc;

    public override GameObject CreateEnemy()
    {
        GameObject enemyObj = Instantiate(prefab);

        Enemy enemy = enemyObj.GetComponent<Enemy>();

        // enemy.SetStrategy(new SlowHeavyStrategy());

        return enemyObj;
    }
}
