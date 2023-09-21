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

    // Index of the selected inventory slot
    //private int selectedSlotIndex = 0;

    /*public void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }*/

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

    public void DisplayScroll(string message)
    {
        //popupText.text = "I am surrounded by books, but I am not a librarian. I stand alone, waiting for your attention. Approach me and press F, and I will reveal to you what grants access to what you seek to seize.";
        popupText.text = message;
        popup.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    private void Update()
    {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    GameObject slot1 = GameObject.Find("Inventory Slot");
                    Image[] itemsInChildren = slot1.GetComponentsInChildren<Image>();
                    Debug.Log("1 button clicked");
                    if (itemsInChildren.Length > 0)
                    {
                        Debug.Log(inventoryManager.getInventory().ToString());
                        List<Item> inventory = inventoryManager.getInventory();
                        Item item = inventory[0];
                        Debug.Log("The item is a " + item);               
                        item.Use();
                    }
                    else
                    {
                        Debug.Log("Child object not found");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    popupText.text = "In this room of levers, two are needed to open the way. But pull them not in haste, for they must both be in play. Listen to the sounds they make, and choose the ones that chime. For when they both are pulled, the path to freedom will be thine";
                    popup.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 1f;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    popupText.text = "I am a game of strategy and wit, With two balls and pedestals, you must commit. Place the balls just right, or you'll be stuck, For the escape door to open, you're in luck. Each ball has its place, make no mistake, Figure out the puzzle, before it's too late.  With your mind sharp and your focus clear, The escape is near, have no fear";
                    popup.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 1f;
                }
            }
}

   
