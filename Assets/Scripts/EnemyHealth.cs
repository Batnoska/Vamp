using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy enemy;

    private EnemyHitFeedback feedback;

    public bool isAlive;

    private void OnEnable()
    {
        isAlive = true;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        feedback = GetComponent<EnemyHitFeedback>();
    }

    public void TakeDamage(HitData hit, HitContext context)
    {
        enemy._health -= hit.damage;

        feedback.PlayHitFeedback(hit, context);

        if (enemy._health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;

        feedback.PlayDeathFeedback();

        GetComponent<Enemy>().ReturnToPool();
    }
}
