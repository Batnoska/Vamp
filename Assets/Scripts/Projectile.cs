using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }
}
