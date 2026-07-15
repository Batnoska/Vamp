using UnityEngine;

public interface IHitEffect
{
    void Apply(EnemyHealth enemy, HitContext context);
}
