using UnityEngine;

public class IceDecorator : HitDecorator
{
    private float slowMultiplier = 0.5f;

    private float slowDuration = 1f;

    public IceDecorator(
        IHitEffect effect)
        : base(effect)
    {
    }

    public override void Apply(
        EnemyHealth enemy,
        HitContext context)
    {
        base.Apply(enemy, context);

        Enemy e =
            enemy.GetComponent<Enemy>();

        if (e == null)
            return;

        e.ApplySlow(
            slowMultiplier,
            slowDuration);
    }
}
