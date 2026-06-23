using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using TypeObject.Normal;
using TypeObject;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<ItemSO> items = new();

    public void AddItem(ItemSO item)
    {
        items.Add(item);

        Debug.Log($"Recogiste {item.name}");

        UseItem(items.Count - 1, this.gameObject);
    }

    public void UseItem(
        int index,
        GameObject user)
    {
        if (index < 0 || index >= items.Count)
            return;

        ItemSO item = items[index];

        if (item is ConsumableItemSO consumable)
        {
            consumable.UseItem(user);
            items.RemoveAt(index);
        }
    }
}
