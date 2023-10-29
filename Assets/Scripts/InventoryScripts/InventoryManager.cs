using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> inventory = new List<Item>(); // list of items in the player's inventory
    [SerializeField] private InventoryUI inventoryUI;

    private const int inventorySize = 8;

    public void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    /* Adds item to the player's inventory */
    public void AddItem(Item item)
    {
        if (isInventoryFull())
        {
            inventory.Add(item);
            inventoryUI.RefreshInventoryUI();
        }
    }

    public List<Item> getInventory()
    {
        return inventory;
    }

    public bool HasItem(Item item)
    {
        return inventory.Contains(item);
    }

    public bool isInventoryFull()
    {
        if (inventory.Count >= inventorySize)
        {
            return false;
        }
        return true;
    }

    public void RemoveItem(Item item) {
        if (inventory.Contains(item)) {
            inventory.Remove(item);
            inventoryUI.RefreshInventoryUI();
        }
    }

}
