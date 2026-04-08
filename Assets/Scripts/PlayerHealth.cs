using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;

    PlayerStateMachine stateMachine;

    void Start()
    {
        stateMachine =
            GetComponent<PlayerStateMachine>();
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
        health -= damage;

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
