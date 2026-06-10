using UnityEngine;

public class BasicHitEffect : IHitEffect
{
    private HitData hitData;

    public BasicHitEffect(HitData hitData)
    {
        this.hitData = hitData;
    }

    public virtual void Apply(
        EnemyHealth enemy,
        HitContext context)
    {
        enemy.TakeDamage(
            hitData,
            context
        );
    }
}
