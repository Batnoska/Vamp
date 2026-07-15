using System.Collections;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private Rigidbody2D rb;
    private PlayerMovement movement;
    private PlayerStateMachine playerStateMachine;

    private bool canDash = true;

    public bool CanDash => canDash;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }

    public void Dash()
    {
        if (!canDash) return;

        Vector2 direction = movement.MoveInput;

        if (direction == Vector2.zero)
        {
            direction = Vector2.right * movement.FacingDirection;
        }
        
        playerStateMachine.ChangeState(
            new DashState(
            direction,
            dashForce,
            dashDuration
            )
            );

        StartCoroutine(DashCooldown());
    }

    IEnumerator DashCooldown()
    {
        canDash = false;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
