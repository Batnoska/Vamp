using System;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] private int damage = 2;

    [SerializeField] private float lifetime = .2f;

    [SerializeField] private float knockbackForce = 7f;

    private HitData hitData;

    private GameObject originPrefab;

    private void Awake()
    {
        hitData = new HitData(damage, knockbackForce);
    }

    public void SetOrigin(GameObject prefab)
    {
        originPrefab = prefab;
    }

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy == null) return;

        Vector2 direction = (other.transform.position - transform.position).normalized;

        HitContext context = new HitContext(direction);
        
        enemy.TakeDamage(hitData, context);
    }

    void ReturnToPool()
    {
        PoolManage.Instance.Release(gameObject, originPrefab);
    }
}
