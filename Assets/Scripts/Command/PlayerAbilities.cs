using System.Collections;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private Rigidbody2D rb;
    private PlayerMovement movement;

    private bool canDash = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    public void Dash()
    {
        if (!canDash) return;

        StartCoroutine(DashRoutine());
    }

    IEnumerator DashRoutine()
    {
        canDash = false;

        Vector2 direction = movement.MoveInput;

        if (direction == Vector2.zero)
        {
            direction = transform.right;
        }

        movement.CanMove = false;

        rb.linearVelocity = direction.normalized * dashForce;

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero;

        movement.CanMove = true;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
