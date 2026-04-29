using System;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] public float _health;
    
    private IObjectPool<GameObject> pool;

    private Transform player;

    private Rigidbody2D rb;

    private float knockbackTimer;

    private GameObject originalPrefab;

    public void SetOrigin(GameObject prefab)
    {
        originalPrefab = prefab;
    }

    public void SetPool(IObjectPool<GameObject> pool)
    {
        this.pool = pool;
    }

    public void ReturnToPool()
    {
        PoolManage.Instance.Release(gameObject, originalPrefab);
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;

        rb.linearVelocity = direction * _speed;
    }

    public void ApplyKnockbackStun(float duration)
    {
        knockbackTimer = duration;
    }

    public float GetDamage()
    {
        return _damage;
    }

    public void SetStats(float speed, float damage, float health)
    {
        this._speed = speed;
        this._damage = damage;
        this._health = health;
    }

    public void SetTarget(Transform target)
    {
        player = target;
    }
}
