using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityInvoker : MonoBehaviour
{
    private ICommand dashCommand;

    [SerializeField] private PlayerAbilities abilities;

    private void Start()
    {
        dashCommand =
            new DashCommand(abilities);
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        dashCommand.Execute();
    }
}
