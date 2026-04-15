using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/SkeletonFactory")]
public class SkeletonFactory : EnemyFactorySO
{
    [SerializeField] GameObject prefab;

    public override EnemyType Type => EnemyType.Skeleton;
    
    public override GameObject CreateEnemy()
    {
        GameObject enemyObj = Instantiate(prefab);

        Enemy enemy = enemyObj.GetComponent<Enemy>();

        // enemy.SetStrategy(new FastStrategy());

        return enemyObj;
    }
}
