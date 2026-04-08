using UnityEngine;

public class MoveState : IPlayerState
{
    private PlayerStateMachine player;

    public bool CanBeInterrupted => true;

    public void Enter(PlayerStateMachine player)
    {
        this.player = player;
    }
    
    public void Update() {}

    public void Exit() {}
}
