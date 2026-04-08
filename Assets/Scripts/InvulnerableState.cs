using UnityEngine;

public class InvulnerableState : IPlayerState
{
    PlayerStateMachine player;

    float timer;

    float duration = 2f;

    float blinkTimer;
    float blinkInterval = 0.1f;

    SpriteRenderer spriteRenderer;

    public bool CanBeInterrupted => false;

    public void Enter(PlayerStateMachine player)
    {
        this.player = player;

        spriteRenderer =
            player.GetComponent<SpriteRenderer>();

        timer = duration;
        blinkTimer = 0f;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        blinkTimer -= Time.deltaTime;

        if (blinkTimer <= 0f ) 
        {
            BlinkEffect();
            blinkTimer = blinkInterval;
        }

        if (timer <= 0)
        {
            if (player.movement.IsMoving) player.ChangeState(new MoveState());
            else
                player.ChangeState(new IdleState());
        }
    }

    void BlinkEffect()
    {
        Color color = spriteRenderer.color;
        color.a = (color.a == 1f) ? 0.3f : 1f;
        spriteRenderer.color = color;
    }

    public void Exit() {}
}
