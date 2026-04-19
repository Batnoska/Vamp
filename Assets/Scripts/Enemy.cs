using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public void SetStats(float speed, float damage)
    {
        this._speed = speed;
        this._damage = damage;
    }
}
