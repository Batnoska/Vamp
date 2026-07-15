using TypeObject.Normal;
using UnityEngine;

[CreateAssetMenu(fileName = "Decorator Effect", menuName = "ScriptableObjects/Type Object Normal/Decorator Effect")]
public class DecoratorShotEffectSo : EffectSO
{
    [SerializeField] private HitDecoratorSO decorator;

    public override void ApplyEffect(EffectData data, GameObject target)
    {
        WeaponController weapon = target.GetComponent<WeaponController>();

        if (weapon == null) return;
        
        weapon.AddDecorator(hit => decorator.CreateDecorator(hit));
    }
}
