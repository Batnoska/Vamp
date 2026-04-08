using UnityEngine;

public class InvulnerableState : IPlayerState
{
    PlayerStateMachine player;

    float timer;

    float duration = 2f;

    SpriteRenderer spriteRenderer;

    public void Enter(PlayerStateMachine player)
    {
        this.player = player;

        Debug.Log("Enter InvulnerableState");

        spriteRenderer =
            player.GetComponent<SpriteRenderer>();

        timer = duration;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        BlinkEffect();

        if (timer <= 0)
        {
            player.ChangeState(new IdleState());
        }
    }

    void BlinkEffect()
    {
        spriteRenderer.enabled =
            !spriteRenderer.enabled;
    }

    public void Exit()
    {
        spriteRenderer.enabled = true;
    }
}
