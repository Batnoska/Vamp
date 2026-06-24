using UnityEngine;

public abstract class HitDecoratorSO : ScriptableObject
{
    public abstract IHitEffect CreateDecorator(IHitEffect baseEffect);
}
