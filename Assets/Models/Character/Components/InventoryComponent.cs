using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private Dictionary<string, bool> inventoryDict = new Dictionary<string, bool>();

    public void AddItemToinventoryDict(string itemName, bool isInInventory = false)
    {
        inventoryDict.Add(itemName, isInInventory);
    }

    public void PickUpItem(string itemName)
    {
        if (inventoryDict.ContainsKey(itemName))
        {
            inventoryDict[itemName] = true;
            Debug.Log($"You take {itemName}.");
        }
        else
        {
            Debug.Log($"Unknow item: {itemName}.");
        }
    }

    public bool CheckItem(string itemName)
    {
        if (inventoryDict.ContainsKey(itemName) && inventoryDict[itemName])
        {
            Debug.Log($"You have {itemName}.");
            return true;
        }
        else
        {
            Debug.Log($"You don't have {itemName}.");
            return false;
        }
    }
}
