using TypeObject;
using TypeObject.Hard;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemSO item;

    public ItemSO Item => item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory =
                other.GetComponent<PlayerInventory>();

            inventory.AddItem(item);

            Destroy(gameObject);
        }
    }
}
