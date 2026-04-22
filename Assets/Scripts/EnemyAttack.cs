using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        
        player.TakeDamage((int)enemy.GetDamage());
    }
}
