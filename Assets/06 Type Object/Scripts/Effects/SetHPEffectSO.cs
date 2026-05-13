using UnityEngine;

namespace TypeObject.Normal
{
    [CreateAssetMenu(fileName = "N Set HP Effect", menuName = "ScriptableObjects/Type Object Normal/Set HP Effect")]
    public class SetHPEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject target)
        {
            HealthComponent hpComp = target.GetComponent<HealthComponent>();

            if (data.ValueIsPercentage)
                hpComp.SetHP(hpComp.CurrentHP * data.Value / 100);
            else
                hpComp.SetHP(data.Value);
        }
    }
}
