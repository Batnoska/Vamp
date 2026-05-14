using UnityEngine;

public class HitData
{
    public int damage;

    public float knockbackForce;


    public HitData(int damage, float knockbackForce)
    {
        this.damage = damage;

        this.knockbackForce = knockbackForce;
    }
}
