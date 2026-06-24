using UnityEngine;

[CreateAssetMenu(menuName = "Decorator Effects/Fire")]
public class FireDecoratorSO : HitDecoratorSO
{
    public override IHitEffect CreateDecorator(IHitEffect baseEffect)
    {
        return new FireDecorator(baseEffect);
    }
}
