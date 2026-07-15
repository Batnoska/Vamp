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

    public List<Func<IHitEffect, IHitEffect>> hitDecorators = new();

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
            
            GetComponent<PlayerAnimator>().PlayAttack();

            currentWeapon?.Attack(transform);
            
            Invoke(nameof(ResetAttack), .1f);
        }
    }

    void ResetAttack()
    {
        IsAttacking = false;
    }

    public void Equip(int weaponIndex)
    {
        switch (weaponIndex)
        {
            case 0:
                EquipKnife();
                break;
            case 1:
                EquipWeapon();
                break;
        }
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
