using UnityEngine;

public class InvulnerableState : IPlayerState
{
    PlayerStateMachine player;

    float timer;

    float duration = 2f;

    float blinkTimer;
    float blinkInterval = 0.1f;

    SpriteRenderer spriteRenderer;

    private bool isTransparent;
    private Color originalColor;

    public bool CanBeInterrupted => false;

    public void Enter(PlayerStateMachine player)
    {
        this.player = player;

        spriteRenderer =
            player.GetComponent<SpriteRenderer>();

        timer = duration;
        blinkTimer = 0f;

        originalColor = spriteRenderer.color;
        isTransparent = false;
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
        isTransparent = !isTransparent;
        
        Color color = originalColor;
        color.a = isTransparent ? 0.3f : 1f;
        spriteRenderer.color = color;
    }

    public void Exit()
    {
        spriteRenderer.color = originalColor;
    }
}
