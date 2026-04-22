using UnityEngine;

public class HitData
{
    public int damage;

    public float knockbackForce;

    public Vector2 hitDirection;

    public HitData(int damage, float knockbackForce, Vector2 direction)
    {
        this.damage = damage;

        this.knockbackForce = knockbackForce;
        
        this.hitDirection = direction;
    }
}
