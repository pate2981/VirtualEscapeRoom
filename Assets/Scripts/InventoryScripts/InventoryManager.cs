using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> inventory = new List<Item>(); // list of items in the player's inventory
    [SerializeField] private InventoryUI inventoryUI;

    public void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    // Create function for checking if inventory is full

    /* Adds scroll to the players inventory*/
    public void AddScroll(Scroll scroll)
    {
        if (isInventoryFull())
        {
            AddItem(scroll);
            inventoryUI.UpdateInventoryUIForScroll(inventory, scroll);  // Call to add the image of item in inventory
        }
    }

    public void AddKey(Key key)
    {
        if (isInventoryFull())
        {
            AddItem(key);
            inventoryUI.UpdateInventoryUI(inventory, key);
        }
    }

    public void AddOrb(Orb orb)
    {
        Debug.Log("Add Orb");
        if (isInventoryFull())
        {
            AddItem(orb);
            inventoryUI.UpdateInventoryUI(inventory, orb);
        }
    }

    public void AddOrb1(Orb1 orb1)
    {
        if (isInventoryFull())
        {
            AddItem(orb1);
            inventoryUI.UpdateInventoryUI(inventory, orb1);
        }
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
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
        if (inventory.Count == 8)
        {
            return false;
        }
        return true;
    }
}
