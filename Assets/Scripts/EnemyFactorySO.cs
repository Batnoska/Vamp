using UnityEngine;

public abstract class EnemyFactorySO : ScriptableObject
{
    public abstract GameObject CreateEnemy();

    public abstract EnemyType Type { get; }
}
