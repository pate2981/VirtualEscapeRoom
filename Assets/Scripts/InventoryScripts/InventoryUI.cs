using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> inventorySlots; // List of images representing inventory slots
    public GameObject popup;    // Popup box
    public TextMeshProUGUI popupText;   // Popup message
    public InventoryManager inventoryManager;
    public GameObject crosshair;

    // Updates UI when scroll is added
    public void UpdateInventoryUIForScroll(List<Item> inventory, Scroll scroll)
    {
        DisplayScroll(scroll.Message);

        // Adds image of scroll to an available inventory slot
        int inventorySpace = inventoryManager.inventory.Count;  // Number of items in inventory
        GameObject inventorySlot = inventorySlots[inventorySpace - 1];  // Inventory slot where item will be placed
        GameObject newObject = Instantiate(scroll.Image, inventorySlot.transform);   // Creates image of item
        newObject.transform.localPosition = Vector3.zero;
    }

    // Displays popup message of the scroll message
    public void DisplayScroll(string message)
    {
        popupText.text = message;
        popup.SetActive(true);
        popupText.fontSize = 18;

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        crosshair.SetActive(false);
    }

    // Closes popupmessage of the scroll message
    public void CloseButton()
    {
        popup.SetActive(false); // Hides the popupbox 
        Cursor.lockState = CursorLockMode.Locked;   // Makes Pointer visible
        Time.timeScale = 1f;    // Locks screen so user can read msg
        crosshair.SetActive(true);
    }

    private void Update()
    {
        // Checks if player has pressed 1 key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject slot1 = GameObject.Find("Inventory Slot 1"); // Retrieves the first inventory slot
            const int slotIndex = 0;    // Index in the array of where the item is 
            CheckInventory(slot1, slotIndex);
        }
        // Checks if player has pressed 2 key
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject slot2 = GameObject.Find("Inventory Slot 2"); // Retrieves the second inventory slot
            const int slotIndex = 1;    // Index in the array of where the item is 
            CheckInventory(slot2, slotIndex);
        }
        // Checks if player has pressed 3 key
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject slot3 = GameObject.Find("Inventory Slot 3"); // Retrieves the third inventory slot
            const int slotIndex = 2;    // Index in the array of where the item is 
            CheckInventory(slot3, slotIndex);
        }
    }

    public void CheckInventory(GameObject slot, int slotNumber)
    {
        Image[] itemsInChildren = slot.GetComponentsInChildren<Image>();

        // Checks if there is an image of an item in the inventory slot
        if (itemsInChildren.Length > 1)
        {
            List<Item> inventory = inventoryManager.getInventory();
            Item item = inventory[slotNumber];
            item.Use(); // Use the item
        }
    }

}

   
