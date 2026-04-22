using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [Min(0)]public int health = 10;

    public event Action<int> OnHealthChanged;

    PlayerStateMachine stateMachine;

    void Start()
    {
        stateMachine =
            GetComponent<PlayerStateMachine>();
        
        OnHealthChanged?.Invoke(health);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (stateMachine.currentState is InvulnerableState) return;

        health -= damage;
        
        OnHealthChanged?.Invoke(health);

        stateMachine.ChangeState(
            new InvulnerableState()
        );

        if (health <= 0)
        {
            stateMachine.ChangeState(
                new DeadState()
            );
        }
    }
}
