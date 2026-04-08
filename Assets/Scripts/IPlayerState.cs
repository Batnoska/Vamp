using UnityEngine;

public interface IPlayerState
{
    void Enter(PlayerStateMachine player);

    void Update();

    void Exit();
}
