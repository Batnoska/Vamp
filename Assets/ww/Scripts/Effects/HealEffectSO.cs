using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Hard
{
    [CreateAssetMenu(fileName = "Heal Effect", menuName = "ScriptableObjects/Type Object/Heal Effect")]
    public class HealEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject user, List<GameObject> targets)
        {
            foreach (GameObject target in targets)
            {
                PlayerHealth hpComp = target.GetComponent<PlayerHealth>();
                
                if (data.ValueIsPercentage)
                    hpComp.Heal(hpComp.maxHealth * data.Value / 100);
                else
                    hpComp.Heal(data.Value);
            }   
        }
    }
}
