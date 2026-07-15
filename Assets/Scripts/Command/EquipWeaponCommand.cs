using UnityEngine;

public class EquipWeaponCommand : ICommand
{
    private readonly WeaponController weaponController;
    private readonly int weaponIndex;

    public EquipWeaponCommand(WeaponController weaponController, int weaponIndex)
    {
        this.weaponController = weaponController;
        this.weaponIndex = weaponIndex;
    }

    public bool CanExecute()
    {
        return true;
    }

    public void Execute()
    {
        Debug.Log($"[Command] EquipWeaponCommand (index: {weaponIndex})");

        weaponController.Equip(weaponIndex);
    }
}
