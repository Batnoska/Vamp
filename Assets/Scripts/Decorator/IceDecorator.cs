using UnityEngine;

public class IceDecorator : HitDecorator
{
    private float slowMultiplier = 0.5f;

    private float slowDuration = 1f;

    private GameObject iceParticlesPrefab;

    public IceDecorator(
        IHitEffect effect,
        GameObject iceParticlesPrefab)
        : base(effect)
    {
        this.iceParticlesPrefab = iceParticlesPrefab;
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

        SpawnIceEffect(e.transform);
    }

    private void SpawnIceEffect(Transform target)
    {
        if (iceParticlesPrefab == null) return;

        GameObject iceEffect =
            Object.Instantiate(iceParticlesPrefab, target.position, Quaternion.identity, target);

        Object.Destroy(iceEffect, slowDuration);
    }
}
