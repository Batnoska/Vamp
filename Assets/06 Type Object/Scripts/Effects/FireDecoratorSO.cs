using UnityEngine;

[CreateAssetMenu(menuName = "Decorator Effects/Fire")]
public class FireDecoratorSO : HitDecoratorSO
{
    [SerializeField] private GameObject explosionPrefab;

    public override IHitEffect CreateDecorator(IHitEffect baseEffect)
    {
        return new FireDecorator(baseEffect, explosionPrefab);
    }
}
