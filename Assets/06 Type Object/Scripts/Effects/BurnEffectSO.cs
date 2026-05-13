using UnityEngine;

namespace TypeObject.Normal
{
    [CreateAssetMenu(fileName = "N Burn Effect", menuName = "ScriptableObjects/Type Object Normal/Burn Effect")]
    public class BurnEffectSO : EffectSO
    {
        public override void ApplyEffect(EffectData data, GameObject target)
        {
            StatusComponent statusComp = target.GetComponent<StatusComponent>();
            statusComp.InflictStatus(Status.Burn, data.Value);
        }
    }
}
