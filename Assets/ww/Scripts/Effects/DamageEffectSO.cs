using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Hard
{  
    [CreateAssetMenu(fileName = "Damage Effect", menuName = "ScriptableObjects/Type Object/Damage Effect")]
    public class DamageEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject user, List<GameObject> targets)
        {
            foreach (GameObject target in targets)
            {
                HealthComponent hpComp = target.GetComponent<HealthComponent>();

                if (data.ValueIsPercentage)
                    hpComp.TakeDamage(hpComp.MaxHP * data.Value / 100);
                else
                    hpComp.TakeDamage(data.Value);
            }
        }
    }
}
