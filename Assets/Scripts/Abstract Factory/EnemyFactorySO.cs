using UnityEngine;

public abstract class EnemyFactorySO : ScriptableObject
{
    [SerializeField] protected GameObject goblinPrefab;
    [SerializeField] protected GameObject orcPrefab;
    [SerializeField] protected GameObject skeletonPrefab;

    public abstract GameObject SpawnGoblin();
    public abstract GameObject SpawnOrc();
    public abstract GameObject SpawnSkeleton();
}
