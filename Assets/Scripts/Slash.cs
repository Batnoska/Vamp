using System;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] private int damage = 2;

    [SerializeField] private float lifetime = .2f;

    [SerializeField] private float knockbackForce = 7f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy == null) return;

        Vector2 direction = (other.transform.position - transform.position).normalized;

        HitData hit = new HitData(
            damage,
            knockbackForce,
            direction
        );
        
        enemy.TakeDamage(hit);
    }
}
