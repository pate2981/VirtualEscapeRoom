using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> inventorySlots; // List of images representing inventory slots
    [SerializeField]
    private GameObject popup;    // Popup box
    [SerializeField]
    private TextMeshProUGUI popupText;   // Popup message
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private GameObject chestSoundObj;
    [SerializeField]
    private ChestAnimation chestAnimat;


    // Updates UI when scroll is added
    public void UpdateInventoryUIForScroll(List<Item> inventory, Scroll scroll)
    {
        DisplayScroll(scroll.Message);

        // Adds image of scroll to an available inventory slot
        int inventorySpace = inventoryManager.getInventory().Count;  // Number of items in inventory
        GameObject inventorySlot = inventorySlots[inventorySpace - 1];  // Inventory slot where item will be placed
        GameObject newObject = Instantiate(scroll.Image, inventorySlot.transform);   // Creates image of item
        newObject.transform.localPosition = Vector3.zero;
    }

    public void UpdateInventoryUIForKey(List<Item> inventory, Key key)
    {
        // Adds image of key to an available inventory slot
        int inventorySpace = inventoryManager.getInventory().Count;  // Number of items in inventory
        GameObject inventorySlot = inventorySlots[inventorySpace - 1];  // Inventory slot where item will be placed
        GameObject newObject = Instantiate(key.Image, inventorySlot.transform);   // Creates image of item
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

    public void OpenChest()
    {

        chestSoundObj.GetComponent<AudioSource>().Play();
        chestAnimat.ChestAnim();
        //collision.gameObject.SetActive(false);
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
        if (Input.GetKeyDown((KeyCode)KeyboardKeys.Key1))
        {
            const int slotIndex = 0;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 2 key
        else if (Input.GetKeyDown((KeyCode)KeyboardKeys.Key2))
        {
            const int slotIndex = 1;    // Index in the array of where the item is 
            HasItem(slotIndex);

        }
        // Checks if player has pressed 3 key
        else if (Input.GetKeyDown((KeyCode)KeyboardKeys.Key3))
        {
            const int slotIndex = 2;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
    }

    public void HasItem(int slotIndex)
    {
        // if statement may not be needed
        if (inventorySlots.Count() - 1 >= slotIndex)
        {
            GameObject slot3 = inventorySlots[slotIndex];
            UseItem(slot3, slotIndex);
        }
    }

    public void UseItem(GameObject slot, int slotNumber)
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

   
