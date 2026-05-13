using System.Collections.Generic;
using UnityEngine;

namespace TypeObject.Normal
{
    [CreateAssetMenu(fileName = "N Consumable Item", menuName = "ScriptableObjects/Type Object Normal/Consumable Item")]
    public class ConsumableItemSO : ItemSO
    {
        [SerializeField] List<EffectPair> effects;

        public void UseItem(GameObject target)
        {
            foreach(EffectPair pair in effects)
                pair.Effect.ApplyEffect(pair.Data, target);
        }
    }

    [System.Serializable]
    public struct EffectPair
    {
        [field:SerializeField] public EffectData Data {  get; private set; }
        [field:SerializeField] public EffectSO Effect { get; private set; }
    }
}

