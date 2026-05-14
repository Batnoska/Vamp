using UnityEngine;

public class KnifeStrategy : IWeaponStrategy
{
    private GameObject slashPrefab;

    private float offset = 1.5f;

    public KnifeStrategy(GameObject prefab)
    {
        slashPrefab = prefab;
    }

    public void Attack(Transform origin)
    {
        float direction = origin.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        Vector3 spawnPosition = origin.position + Vector3.right * (direction * offset);

        Quaternion rotation = direction == 1 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        GameObject slash = PoolManage.Instance.Get(slashPrefab);

        slash.transform.position = spawnPosition;
        slash.transform.rotation = rotation;

        slash.GetComponent<Slash>()?.SetOrigin(slashPrefab);
    }
}
