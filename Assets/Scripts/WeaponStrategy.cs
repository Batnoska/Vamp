using UnityEngine;

public class WeaponStrategy : IWeaponStrategy
{
    private GameObject projectilePrefab;

    private int bulletCount = 3;
    private float spreadAngle = 25f;
    private float offset = 1f;

    public WeaponStrategy(GameObject prefab)
    {
        projectilePrefab = prefab;
    }

    public void Attack(Transform origin)
    {
        SpriteRenderer sprite = origin.GetComponent<SpriteRenderer>();

        float direction = sprite.flipX ? -1 : 1;

        Vector3 spawnPosition = origin.position + Vector3.right * (direction * offset);

        float startAngle = -spreadAngle * .5f;

        float angleStep = spreadAngle / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + angleStep * i;
            
            Quaternion rotation = Quaternion.Euler(0, direction == 1 ? 0 : 180, angle * direction);

            GameObject bullet = PoolManage.Instance.Get(projectilePrefab);

            bullet.transform.position = spawnPosition;
            bullet.transform.rotation = rotation;

            bullet.GetComponent<Projectile>()?.SetOrigin(projectilePrefab);
        }
    }
}
