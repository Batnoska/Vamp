using UnityEngine;

[CreateAssetMenu(menuName = "Decorator Effects/Ice")]
public class IceDecoratorSO : HitDecoratorSO
{
    public override IHitEffect CreateDecorator(IHitEffect baseEffect)
    {
        return new IceDecorator(baseEffect);
    }
}
