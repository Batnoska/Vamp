using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lifetime = 3f;

    [SerializeField] private int damage = 1;

    [SerializeField] private float knockbackForce = 4f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
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

        HitData hit = new HitData(
            damage,
            knockbackForce,
            direction
        );
        
        enemy.TakeDamage(hit);
        
        Destroy(gameObject);
    }
}
