using UnityEngine;

namespace TypeObject.Normal
{
    [System.Serializable]
    public struct EffectData
    {
        // Value puede ser cualquier cosa
        // Daño realizado, vida a curar, cantidad de turnos de veneno, etc.
        [field: SerializeField] public int Value { get; private set; }

        // Para distinguir entre curar 50 HP y 50%, usamos este bool
        [field: SerializeField] public bool ValueIsPercentage { get; private set; }
    }
}
