using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lifetime = 3f;

    [SerializeField] private int damage = 1;

    [SerializeField] private float knockbackForce = 4f;

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

    private void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy == null) return;
        
        Vector2 direction = (other.transform.position - transform.position).normalized;

        HitContext context = new HitContext(direction);
        
        enemy.TakeDamage(hitData, context);

        ReturnToPool();
    }

    void ReturnToPool()
    {
        PoolManage.Instance.Release(gameObject, originPrefab);
    }
}
