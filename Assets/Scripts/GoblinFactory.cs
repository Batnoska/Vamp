using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemies/GoblinFactory")]
public class GoblinFactory : EnemyFactorySO
{
    [SerializeField] GameObject prefab;

    public override EnemyType Type => EnemyType.Goblin;

    public override GameObject CreateEnemy()
    {
        GameObject enemyObj = Instantiate(prefab);

        Enemy enemy = enemyObj.GetComponent<Enemy>();

        // enemy.SetStrategy(new FollowPlayerStrategy());

        return enemyObj;
    }
}
