using UnityEngine;

public class FireDecorator : HitDecorator
{
    private float splashRadius = 2f;

    private int splashDamage = 1;

    private GameObject explosionPrefab;

    public FireDecorator(
        IHitEffect effect,
        GameObject explosionPrefab)
        : base(effect)
    {
        this.explosionPrefab = explosionPrefab;
    }

    public override void Apply(
        EnemyHealth enemy,
        HitContext context)
    {
        base.Apply(enemy, context);

        SpawnExplosionEffect(enemy.transform.position);

        Collider2D[] hits =
            Physics2D.OverlapCircleAll(
                enemy.transform.position,
                splashRadius);

        foreach (Collider2D hit in hits)
        {
            EnemyHealth otherEnemy =
                hit.GetComponent<EnemyHealth>();

            if (otherEnemy == null)
                continue;

            if (otherEnemy == enemy)
                continue;

            HitData splashHit =
                new HitData(
                    splashDamage,
                    0f);

            otherEnemy.TakeDamage(
                splashHit,
                context);
        }
    }

    private void SpawnExplosionEffect(Vector2 position)
    {
        if (explosionPrefab == null) return;

        GameObject explosion =
            Object.Instantiate(explosionPrefab, position, Quaternion.identity);

        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();

        float destroyDelay = 1f;

        if (ps != null)
        {
            ParticleSystem.ShapeModule shape = ps.shape;
            shape.radius = splashRadius;

            ps.Play();

            destroyDelay = ps.main.duration + ps.main.startLifetime.constantMax;
        }

        Object.Destroy(explosion, destroyDelay);
    }
}
