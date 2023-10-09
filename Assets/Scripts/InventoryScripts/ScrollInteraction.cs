using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollInteraction : MonoBehaviour
{
    [SerializeField]
    private InventoryManager inventoryManager;

    public void OnMouseDown()
    {
        // Gets the Scroll 
        Scroll scroll = GetComponent<Scroll>();

        // Adds the scroll to the player's inventory
        inventoryManager.AddScroll(scroll);

        // Removes the visibility of scroll object from game world
        gameObject.SetActive(false); 
    }
}
