using UnityEngine;

public class CombatFacade : MonoBehaviour
{
    private Enemy enemy;
    private EnemyHealth health;
    private EnemyHitFeedback feedback;

    [SerializeField]
    private EnemyDeathEventChannelSO enemyDeathChannel;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();

        health = GetComponent<EnemyHealth>();

        feedback = GetComponent<EnemyHitFeedback>();
    }

    public void DamageEnemy(
        HitData hit,
        HitContext context)
    {
        health.ApplyDamage(hit);

        feedback.PlayHitFeedback(hit, context);

        if (health.IsDead())
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        health.SetDead();

        feedback.PlayDeathFeedback();

        enemyDeathChannel.RaiseEvent(enemy);

        enemy.ReturnToPool();
    }
}
