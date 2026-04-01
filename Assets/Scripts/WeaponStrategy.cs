using UnityEngine;

public class WeaponStrategy : IWeaponStrategy
{
    private GameObject projectilePrefab;

    public WeaponStrategy(GameObject prefab)
    {
        projectilePrefab = prefab;
    }

    public void Attack(Transform origin)
    {
        Object.Instantiate(
            projectilePrefab,
            origin.position,
            Quaternion.identity
        );
    }
}
