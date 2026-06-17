using TypeObject.Normal;
using UnityEngine;

namespace TypeObject.Normal
{
    [CreateAssetMenu(fileName = "N Fire Shot Effect", menuName = "ScriptableObjects/Type Object Normal/Fire Shot Effect")]
    public class FireShotEffectSO : EffectSO
   {
        public override void ApplyEffect(EffectData data, GameObject target)
        {
            WeaponController weaponController =
            target.GetComponent<WeaponController>();

            if (weaponController == null)
                return;

            weaponController.AddDecorator(hit => new FireDecorator(hit));
        }
    }
}
