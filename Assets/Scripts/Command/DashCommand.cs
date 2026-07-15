using UnityEngine;

public class DashCommand : ICommand
{
    private PlayerAbilities abilities;
    float bufferTime;
    float timestamp;

    public DashCommand(PlayerAbilities abilities, float bufferTime)
    {
        this.abilities = abilities;
        this.bufferTime = bufferTime;
        timestamp = Time.time;
    }

    public bool CanExecute()
    {
        if (Time.time > timestamp + bufferTime) return false;
        return abilities.CanDash;
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
