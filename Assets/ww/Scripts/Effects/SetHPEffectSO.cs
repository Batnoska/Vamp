using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Hard
{
    [CreateAssetMenu(fileName = "Set HP Effect", menuName = "ScriptableObjects/Type Object/Set HP Effect")]
    public class SetHPEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject user, List<GameObject> targets)
        {
            foreach (GameObject target in targets)
            {
                HealthComponent hpComp = target.GetComponent<HealthComponent>();

                if (data.ValueIsPercentage)
                    hpComp.SetHP(hpComp.CurrentHP * data.Value / 100);
                else
                    hpComp.SetHP(data.Value);
            }
        }
    }
}
