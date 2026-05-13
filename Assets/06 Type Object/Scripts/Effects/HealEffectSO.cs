using UnityEngine;

namespace TypeObject.Normal
{
    [CreateAssetMenu(fileName = "N Heal Effect", menuName = "ScriptableObjects/Type Object Normal/Heal Effect")]
    public class HealEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject target)
        {
            PlayerHealth hpComp = target.GetComponent<PlayerHealth>();

            if (data.ValueIsPercentage)
                hpComp.Heal(hpComp.maxHealth * data.Value / 100);
            else
                hpComp.Heal(data.Value);
        }
    }
}
