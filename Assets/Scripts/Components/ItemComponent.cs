using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [Header("Item parameters")]
    [SerializeField] private string itemName;

    private InventoryComponent inventory;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryComponent>();

        inventory.AddItemToinventoryDict(itemName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inventory.PickUpItem(itemName);
            Destroy(gameObject);
        }
    }
}
