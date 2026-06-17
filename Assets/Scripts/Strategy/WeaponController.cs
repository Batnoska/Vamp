using System;
using System.Collections.Generic;
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

    KnifeStrategy knifeStrategy;
    ShotgunStrategy shotgunStrategy;

    private List<Func<IHitEffect, IHitEffect>> hitDecorators = new();

    public IReadOnlyList<Func<IHitEffect, IHitEffect>> HitDecorators => hitDecorators;

    public void AddDecorator(Func<IHitEffect, IHitEffect> decorator)
    {
        hitDecorators.Add(decorator);
    }

    public void RemoveDecorator(Func<IHitEffect, IHitEffect> decorator)
    {
        hitDecorators.Remove(decorator);
    }

    void Start()
    {
        knifeStrategy = new KnifeStrategy(knifePrefab);
        shotgunStrategy = new ShotgunStrategy(weaponPrefab, this);

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
        currentWeapon = knifeStrategy;
    }

    public void EquipWeapon()
    {
        currentWeapon = shotgunStrategy;
    }
}
