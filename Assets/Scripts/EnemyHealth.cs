using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy enemy;

    private EnemyHitFeedback feedback;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        feedback = GetComponent<EnemyHitFeedback>();
    }

    public void TakeDamage(HitData hit)
    {
        enemy._health -= hit.damage;

        feedback.PlayHitFeedback(hit);

        if (enemy._health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        feedback.PlayDeathFeedback();
        
        Destroy(gameObject);
    }
}
