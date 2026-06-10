using UnityEngine;

public class FireDecorator : HitDecorator
{
    public FireDecorator(
        IHitEffect effect)
        : base(effect)
    {
    }

    public override void Apply(
        EnemyHealth enemy,
        HitContext context)
    {
        base.Apply(
            enemy,
            context
        );

        Debug.Log("Enemy Burned");
    }
}
