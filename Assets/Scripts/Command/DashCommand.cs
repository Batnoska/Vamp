using UnityEngine;

public class DashCommand : ICommand
{
    private PlayerAbilities abilities;

    public DashCommand(PlayerAbilities abilities)
    {
        this.abilities = abilities;
    }

    public bool CanExecute()
    {
        return abilities.CanDash;
    }

    public void Execute()
    {
        Debug.Log("[Command] DashCommand");

        abilities.Dash();
    }
}
