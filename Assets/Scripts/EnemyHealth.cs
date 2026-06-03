using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyDeathEventChannelSO enemyDeathChannel;
    
    private Enemy enemy;

    private EnemyHitFeedback feedback;
    private CombatFacade combatFacade;

    public bool isAlive;

    public bool IsDead()
    {
        return enemy._health <= 0;
    }

    public void SetDead()
    {
        isAlive = false;
    }

    private void OnEnable()
    {
        isAlive = true;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        feedback = GetComponent<EnemyHitFeedback>();
        combatFacade = GetComponent<CombatFacade>();
    }

    public void TakeDamage(HitData hit, HitContext context)
    {
        combatFacade.DamageEnemy(hit, context);
    }

    public void ApplyDamage(HitData hit)
    {
        enemy._health -= hit.damage;
    }
}
