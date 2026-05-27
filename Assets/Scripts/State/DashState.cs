using UnityEngine;

public class DashState : IPlayerState
{
    private PlayerStateMachine player;

    private Vector2 dashDirection;

    private float dashForce;
    private float dashDuration;

    private float timer;

    private Rigidbody2D rb;

    public bool CanBeInterrupted => false;

    public DashState(
        Vector2 direction,
        float force,
        float duration)
    {
        dashDirection = direction.normalized;
        dashForce = force;
        dashDuration = duration;
    }

    public void Enter(PlayerStateMachine player)
    {
        this.player = player;

        rb = player.GetComponent<Rigidbody2D>();

        timer = dashDuration;

        player.movement.CanMove = false;

        rb.linearVelocity =
            dashDirection * dashForce;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            rb.linearVelocity = Vector2.zero;

            player.movement.CanMove = true;

            if (player.movement.IsMoving)
            {
                player.ChangeState(new MoveState());
            }
            else
            {
                player.ChangeState(new IdleState());
            }
        }
    }

    public void Exit()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
