using UnityEngine;

public class FireDecorator : HitDecorator
{
    private float splashRadius = 2f;

    private int splashDamage = 1;

    public FireDecorator(
        IHitEffect effect)
        : base(effect)
    {
    }

    public override void Apply(
        EnemyHealth enemy,
        HitContext context)
    {
        base.Apply(enemy, context);

        Collider2D[] hits =
            Physics2D.OverlapCircleAll(
                enemy.transform.position,
                splashRadius);

        foreach (Collider2D hit in hits)
        {
            EnemyHealth otherEnemy =
                hit.GetComponent<EnemyHealth>();

            if (otherEnemy == null)
                continue;

            if (otherEnemy == enemy)
                continue;

            HitData splashHit =
                new HitData(
                    splashDamage,
                    0f);

            otherEnemy.TakeDamage(
                splashHit,
                context);
        }
    }
}
