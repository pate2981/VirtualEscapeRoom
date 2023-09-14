using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>(); // list of items in the player's inventory
    public InventoryUI inventoryUI;

    public void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    /* Adds scroll to the players inventory*/
    public void AddScroll(Scroll scroll)
    {        
        inventory.Add(scroll);
        inventoryUI.UpdateInventoryUIForScroll(inventory, scroll);  // Call to add the image of item in inventory
    }

    public bool HasItem(Item item)
    {
        return inventory.Contains(item);
    }
}
