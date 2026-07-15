using UnityEngine;

[CreateAssetMenu(menuName = "Decorator Effects/Ice")]
public class IceDecoratorSO : HitDecoratorSO
{
    [SerializeField] private GameObject iceParticlesPrefab;

    public override IHitEffect CreateDecorator(IHitEffect baseEffect)
    {
        return new IceDecorator(baseEffect, iceParticlesPrefab);
    }
}
