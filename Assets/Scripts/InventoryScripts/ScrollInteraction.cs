using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollInteraction : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public void OnMouseDown()
    {
        // Gets the Scroll 
        Scroll scroll = GetComponent<Scroll>();

        // Adds the scroll to the player's inventory
        inventoryManager.AddScroll(scroll);

        // Destroys the scroll prefab in the game world
        Destroy(gameObject);
    }
}
