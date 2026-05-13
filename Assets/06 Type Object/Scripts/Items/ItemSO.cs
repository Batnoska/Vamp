using UnityEngine;

namespace TypeObject
{
    public abstract class ItemSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public ItemRarity Rarity { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
    public enum ItemRarity { Common, Rare, Epic, Legendary }
}
