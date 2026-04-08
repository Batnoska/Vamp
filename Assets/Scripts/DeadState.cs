using UnityEngine;

public class DeadState : IPlayerState
{
    private PlayerStateMachine player;

    public void Enter(PlayerStateMachine player)
    {
        this.player = player;

        player.movement.StopMovement();

        player.weaponController.enabled = false;
        
        
        player.gameObject.SetActive(false);
    }
    
    public void Update() {}
    
    public void Exit() {}
}
