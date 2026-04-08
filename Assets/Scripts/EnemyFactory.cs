using UnityEngine;

public static class EnemyFactory
{
    public static GameObject CreateEnemy(EnemyType type, GameObject prefab)
    {
        GameObject enemyObj = GameObject.Instantiate(prefab);

        // Enemy enemy = enemyObj.GetComponent<Enemy>();

        // switch (type)
        // {
        //     case EnemyType.Goblin:
        //         enemy.SetStrategy(new FollowPlayerStrategy());
        //         break;
        //     
        //     case EnemyType.Orc:
        //         enemy.SetStrategy(new SlowHeavyStrategy());
        //         break;
        //     
        //     case EnemyType.Skeleton:
        //         enemy.SetStrategy(new FastStrategy());
        //         break;
        // }

        return enemyObj;
    }

    public static EnemyType GetRandomType()
    {
        return (EnemyType)Random.Range(0, 3);
    }
}
