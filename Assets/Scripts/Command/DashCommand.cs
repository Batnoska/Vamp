using UnityEngine;

public class DashCommand : ICommand
{
    private PlayerAbilities abilities;

    public DashCommand(PlayerAbilities abilities)
    {
        this.abilities = abilities;
    }

    public void Execute()
    {
        abilities.Dash();
    }
}
