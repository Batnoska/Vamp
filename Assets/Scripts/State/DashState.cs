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
        
        player.GetComponent<PlayerAnimator>().PlayRoll();

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

            if (player.movement.IsMoving)
            {
                player.ChangeState(player.moveState);
            }
            else
            {
                player.ChangeState(player.idleState);
            }
        }
    }

    public void Exit()
    {
        rb.linearVelocity = Vector2.zero;

        player.movement.CanMove = true;
    }
}
