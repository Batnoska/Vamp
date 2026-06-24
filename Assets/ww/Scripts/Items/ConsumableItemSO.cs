using UnityEngine;
using System.Collections.Generic;

namespace TypeObject.Hard
{
    [CreateAssetMenu(fileName = "Consumable Item", menuName = "ScriptableObjects/Type Object/Consumable Item")]
    public class ConsumableItemSO : ItemSO
    {
        // En caso de que un item tenga varios efectos, los ponemos en una lista
        // Separamos el codigo del efecto de sus datos
        // Si no, tendriamos muchos SOs para curar distintas cantidades a distintos targets
        // Entonces usamos un struct EffectPair que junta una función (SO) con sus datos
        // Ese struct es especifico de cada item, como deberia ser
        [field: SerializeField] List<EffectPair> effects;

        // Asumimos que cada efecto tiene sus propios targets 
        // Ej: bajarse la vida a 1HP, luego curar al maximo a todos los aliados
        // Agregamos una funcion que devuelva que targets se pueden elegir para cada efecto
        // Entendemos que esto se usa en un menu de seleccion de targets
        // Luego se aplica el efecto
        public List<TargettingRules> GetEffectsTargetting()
        {
            List<TargettingRules> targettingRules = new ();
            
            foreach (EffectPair effect in effects)
                targettingRules.Add(effect.Data.TargettingRules);

            return targettingRules;
        }

        // Cada efecto tiene su lista de targets
        // Ej: Efecto 1 -> Aliado B
        //     Efecto 2 -> Enemigo A, Enemigo B, Enemigo C
        // Entonces es una lista de listas de targets
        public void Use(GameObject user, List<List<GameObject>> targetSets)
        {
            for(int i = 0; i < effects.Count; i++)
                effects[i].Effect.ApplyEffect(effects[i].Data, user, targetSets[i]);
        }
    }

   // Este struct entonces almacena un efecto y toda la informacion para aplicarlo
   [System.Serializable]
   public struct EffectPair
    {
        [field: SerializeField] public EffectSO Effect { get; private set; }
        [field: SerializeField] public EffectData Data { get; private set; }
    }

}
