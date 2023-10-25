using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots; // List of images representing inventory slots
    [SerializeField] private GameObject popup;    // Popup box
    [SerializeField] private TextMeshProUGUI popupText;   // Popup message
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject chestSoundObj;
    [SerializeField] private ChestAnimation chestAnimat;
    [SerializeField] private Orbsync orOne;
    [SerializeField] private OrbOneSync orTwo;

    public void UpdateInventoryUI(List<Item> inventory, Item item)
    {
        // Adds image of item to an available inventory slot
        int inventorySpace = inventoryManager.getInventory().Count;  // Number of items in inventory
        GameObject inventorySlot = inventorySlots[inventorySpace - 1];  // Inventory slot where item will be placed
        GameObject image = Instantiate(item.Image, inventorySlot.transform);   // Creates image of item
        image.transform.localPosition = Vector3.zero;
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

    public void PlaceOrb()
    {
        orOne.orbSync();
    }

    public void PlaceOrb1()
    {
        orTwo.orbOneSync();
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
        if (Input.GetKeyDown((KeyCode)KeyBind.Key1))
        {
            const int slotIndex = 0;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 2 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key2))
        {
            const int slotIndex = 1;    // Index in the array of where the item is 
            HasItem(slotIndex);

        }
        // Checks if player has pressed 3 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key3))
        {
            const int slotIndex = 2;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 4 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key4))
        {
            const int slotIndex = 3;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 5 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key5))
        {
            const int slotIndex = 4;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 6 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key6))
        {
            const int slotIndex = 5;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 7 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key7))
        {
            const int slotIndex = 6;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
        // Checks if player has pressed 8 key
        else if (Input.GetKeyDown((KeyCode)KeyBind.Key8))
        {
            const int slotIndex = 7;    // Index in the array of where the item is 
            HasItem(slotIndex);
        }
    }

    public void HasItem(int slotIndex)
    {
        // if statement may not be needed
        if (inventorySlots.Count() - 1 >= slotIndex)
        {
            GameObject slot = inventorySlots[slotIndex];
            UseItem(slot, slotIndex);
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

   
