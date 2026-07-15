using UnityEngine;

public class IdleState : IPlayerState
{
    private PlayerStateMachine player;

    public bool CanBeInterrupted => true;
    public void Enter(PlayerStateMachine player)
    {
        this.player = player;
        
        player.GetComponent<PlayerAnimator>().SetMoving(false);

        player.movement.StopMovement();
    }

    public void Update() {}

    public void Exit() {}
}
