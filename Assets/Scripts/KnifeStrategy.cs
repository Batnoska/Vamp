using UnityEngine;

public class KnifeStrategy : IWeaponStrategy
{
    private GameObject projectilePrefab;

    public KnifeStrategy(GameObject prefab)
    {
        projectilePrefab = prefab;
    }

    public void Attack(Transform origin)
    {
        GameObject projectile = Object.Instantiate(
            projectilePrefab,
            origin.position,
            Quaternion.identity
        );

        projectile.transform.right = origin.right;
    }
}
