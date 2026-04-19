using UnityEngine;

public abstract class EnemyFactorySO : ScriptableObject
{
    [SerializeField] protected GameObject goblinPrefab;

    [SerializeField] protected GameObject orcPrefab;

    [SerializeField] protected GameObject skeletonPrefab;

    public abstract GameObject CreateGoblin();

    public abstract GameObject CreateOrc();

    public abstract GameObject CreateSkeleton();
}
