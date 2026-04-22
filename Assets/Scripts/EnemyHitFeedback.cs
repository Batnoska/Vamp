using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHitFeedback : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private ParticleSystem bloodParticles;

    [SerializeField] private GameObject bloodPool;

    private Color originalColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        spriteRenderer =
            GetComponent<SpriteRenderer>();

        originalColor =
            spriteRenderer.color;
    }
    
    public void PlayHitFeedback(HitData hit)
    {
        ApplyKnockback(hit);
        
        SpawnBloodParticles(hit);

        StartCoroutine(HitFlash());

    }
    
    void ApplyKnockback(HitData hit)
    {
        Enemy enemy = GetComponent<Enemy>();
        
        enemy.ApplyKnockbackStun(0.3f);
        
        rb.AddForce(
            hit.hitDirection *
            hit.knockbackForce,
            ForceMode2D.Impulse
        );
    }
    
    IEnumerator HitFlash()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = originalColor;
    }
    
    void SpawnBloodParticles(HitData hit)
    {
        if (bloodParticles == null) return;

        bloodParticles.transform.right =
            hit.hitDirection;

        Instantiate(
            bloodParticles,
            transform.position,
            quaternion.identity
        );
    }
    
    public void PlayDeathFeedback()
    {
        Instantiate(
            bloodPool,
            transform.position,
            Quaternion.identity
        );
    }
}
