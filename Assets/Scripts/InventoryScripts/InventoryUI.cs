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

    public void Start()
    {
    }

    // Updates UI when scroll is added
    public void UpdateInventoryUIForScroll(List<Item> inventory, Scroll scroll)
    {
        popup.SetActive(true);  // Displays popup message
        popupText.text = scroll.Message;
        popupText.fontSize = 18;
        Cursor.lockState = CursorLockMode.None; // Locks screen
        Time.timeScale = 0f;    

        // Adds image of scroll to an available inventory slot
        int inventorySpace = inventoryManager.inventory.Count;  // Number of items in inventory
        GameObject inventorySlot = inventorySlots[inventorySpace - 1];  // Inventory slot where item will be placed
        GameObject newObject = Instantiate(scroll.Image, inventorySlot.transform);   // Creates image of item
        newObject.transform.localPosition = Vector3.zero;
    }
}
