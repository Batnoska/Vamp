using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    private IWeaponStrategy currentWeapon;

    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject weaponPrefab;

    private float attackTimer;
    
    [SerializeField] float attackRate = 1f;
    
    public bool IsAttacking { get; private set; }

    void Start()
    {
        EquipKnife();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackRate)
        {
            attackTimer = 0f;

            IsAttacking = true;

            currentWeapon?.Attack(transform);
            
            Invoke(nameof(ResetAttack), .1f);
        }
    }

    void ResetAttack()
    {
        IsAttacking = false;
    }

    public void OnSwitchWeapon1(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        EquipKnife();
    }

    public void OnSwitchWeapon2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        EquipWeapon();
    }

    public void EquipKnife()
    {
        currentWeapon =
            new KnifeStrategy(knifePrefab);
    }

    public void EquipWeapon()
    {
        currentWeapon =
            new WeaponStrategy(weaponPrefab);
    }
}
