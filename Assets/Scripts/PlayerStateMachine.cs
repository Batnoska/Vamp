using System;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private IPlayerState currentState;

    public PlayerMovement movement;

    public WeaponController weaponController;

    public void ChangeState(IPlayerState newState)
    {
        Debug.Log("Changing state to: " + newState.GetType().Name);
        
        currentState?.Exit();

        currentState = newState;
        
        currentState.Enter(this);
    }

    private void Start()
    {
        ChangeState(new MoveState());
    }

    private void Update()
    {
        HandleMovementState();
        
        currentState?.Update();
    }

    void HandleMovementState()
    {
        if (movement.IsMoving && !(currentState is MoveState))
        {
            ChangeState(new MoveState());
        } else if (!movement.IsMoving && !(currentState is IdleState))
        {
            ChangeState(new IdleState());
        }
    }
}
