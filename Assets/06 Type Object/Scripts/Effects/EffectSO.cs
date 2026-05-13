using UnityEngine;

namespace TypeObject.Normal
{
    public abstract class EffectSO : ScriptableObject
    {
        public abstract void ApplyEffect(EffectData data, GameObject target);
    }
}

