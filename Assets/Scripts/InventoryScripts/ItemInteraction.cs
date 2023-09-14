using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Item item; // the item associated with this script

    // Add this function to handle the click event
    public void OnMouseDown()
    {
        /*Debug.Log("Clicked on object");
        // Add the item to the player's inventory
        InventoryManager.inventory.Add(item);
        // Remove this GameObject from the game world
        Destroy(gameObject);*/
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with object");
        // add any specific interactions for this item here
    }

}
