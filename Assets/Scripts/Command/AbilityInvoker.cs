using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityInvoker : MonoBehaviour
{
    private Dictionary<string, ICommand> commands = new();
    private Queue<ICommand> commandQueue = new();

    [SerializeField] private int maxQueuedCommands = 2;

    [SerializeField] private PlayerStateMachine playerStateMachine;

    [SerializeField] private PlayerAbilities abilities;
    [SerializeField] private WeaponController weaponController;

    private void Start()
    {
        commands["Dash"] = new DashCommand(abilities);
        commands["EquipKnife"] = new EquipWeaponCommand(weaponController, 0);
        commands["EquipWeapon"] = new EquipWeaponCommand(weaponController, 1);
    }

    private void ExecuteCommand(ICommand command)
    {
        if (playerStateMachine.currentState.CanBeInterrupted)
        {
            command.Execute();
        }
        else
        {
            if (commandQueue.Count < maxQueuedCommands)
            {
                commandQueue.Enqueue(command);
                
                Debug.Log($"Command queued: {command.GetType().Name}");
            }
        }
    }

    private void Update()
    {
        if (commandQueue.Count == 0 || !playerStateMachine.currentState.CanBeInterrupted)
        {
            return;
        }

        int count = commandQueue.Count;

        for (int i = 0; i < count; i++)
        {
            ICommand command = commandQueue.Peek();

            if (command.CanExecute())
            {
                command.Execute();

                commandQueue.Dequeue();

                break;
            }

            commandQueue.Enqueue(commandQueue.Dequeue());
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        ExecuteCommand(commands["Dash"]);
    }

    public void OnSwitchWeapon1(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        ExecuteCommand(commands["EquipKnife"]);
    }

    public void OnSwitchWeapon2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        ExecuteCommand(commands["EquipWeapon"]);
    }
}
