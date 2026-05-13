using UnityEngine;

namespace TypeObject.Normal
{
    [CreateAssetMenu(fileName = "N Damage Effect", menuName = "ScriptableObjects/Type Object Normal/Damage Effect")]
    public class DamageEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject target)
        {
            HealthComponent hpComp = target.GetComponent<HealthComponent>();
            
            if (data.ValueIsPercentage)
                hpComp.TakeDamage(hpComp.MaxHP * data.Value / 100);
            else
                hpComp.TakeDamage(data.Value);
        }
    }
}