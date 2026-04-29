using UnityEngine;

public abstract class EnemyFactorySO : ScriptableObject
{
    [SerializeField] protected GameObject goblinPrefab;

    [SerializeField] protected GameObject orcPrefab;

    [SerializeField] protected GameObject skeletonPrefab;

    public GameObject GetGoblinPrefab() => goblinPrefab;
    public GameObject GetOrcPrefab() => orcPrefab;
    public GameObject GetSkeletonPrefab() => skeletonPrefab;

    public abstract void ConfigureGoblin(GameObject enemy);
    public abstract void ConfigureOrc(GameObject enemy);
    public abstract void ConfigureSkeleton(GameObject enemy);


    public abstract GameObject CreateGoblin();

    public abstract GameObject CreateOrc();

    public abstract GameObject CreateSkeleton();
}
