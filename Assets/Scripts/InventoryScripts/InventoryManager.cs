using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private List<Item> inventory = new List<Item>(); // list of items in the player's inventory
    [SerializeField]
    private InventoryUI inventoryUI;

    public void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    // Create function for checking if inventory is full

    /* Adds scroll to the players inventory*/
    public void AddScroll(Scroll scroll)
    {        
        inventory.Add(scroll);
        //Debug.Log("The inventory space: " + inventory.Count);
        inventoryUI.UpdateInventoryUIForScroll(inventory, scroll);  // Call to add the image of item in inventory
    }

    public List<Item> getInventory()
    {
        return inventory;
    }

    public bool HasItem(Item item)
    {
        return inventory.Contains(item);
    }
}
