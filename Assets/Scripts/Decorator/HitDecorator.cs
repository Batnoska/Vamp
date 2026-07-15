using UnityEngine;

public abstract class HitDecorator : IHitEffect
{
    protected IHitEffect wrappedEffect;

    protected HitDecorator(
        IHitEffect effect)
    {
        wrappedEffect = effect;
    }

    public virtual void Apply(
        EnemyHealth enemy,
        HitContext context)
    {
        wrappedEffect.Apply(
            enemy,
            context
        );
    }
}
