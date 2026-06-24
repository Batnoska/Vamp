using UnityEngine;
using System.Collections.Generic;

namespace TypeObject.Hard
{
    // Clase base para todos los efectos
    // El efecto necesita datos (daño, etc.), quien lo usa y todos los afectados
    public abstract class EffectSO : ScriptableObject
    {
        public abstract void ApplyEffect(EffectData data, GameObject user, List<GameObject> targets);
    }  

    [System.Serializable]
    public struct EffectData
    {
        // Value puede ser cualquier cosa
        // Daño realizado, vida a curar, cantidad de turnos de veneno, etc.
        [field: SerializeField] public int Value { get; private set; }

        // Para distinguir entre curar 50 HP y 50%, usamos este bool
        [field: SerializeField] public bool ValueIsPercentage { get; private set; }

        // Si el efecto puede ser aplicado solo a algunos targets, se especifica aca
        [field: SerializeField] public TargettingRules TargettingRules { get; private set; }
    }

    public enum TargettingRules
    {
        Self, SingleAlly, SingleEnemy, All, AllAllies,
        AllEnemies, AllButSelf, AllAlliesButSelf
    }
}
