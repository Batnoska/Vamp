using UnityEngine;

namespace TypeObject
{
    public class HealthComponent : MonoBehaviour
    {
        [field: SerializeField] public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;

            // TODO: implementar muerte
            if (CurrentHP <= 0)
                Debug.Log("Dead");
        }

        public void Heal(int healAmount)
        {
            CurrentHP += healAmount;

            if (CurrentHP > MaxHP)
                CurrentHP = MaxHP;
        }

        public void SetHP(int newValue)
        {
            CurrentHP = newValue;

            // TODO: implementar muerte
            if (CurrentHP <= 0)
                Debug.Log("Dead");

            if (CurrentHP > MaxHP)
                CurrentHP = MaxHP;
        }
    }
}