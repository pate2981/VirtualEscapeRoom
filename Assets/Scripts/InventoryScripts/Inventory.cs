using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Array of inventory slots
    public GameObject[] inventorySlots;

    public TextMeshProUGUI popupText;

    public GameObject popupBox;

    // Array of outlines for the inventory slots
    private Outline[] slotOutlines;

    // Index of the selected inventory slot
    private int selectedSlotIndex = 0;

    private void Start()
    {
        popupText.fontSize = 18;
    }

public int GetSelectedSlot()
    {
        return selectedSlotIndex;
    }


    public void AddItem(Item item)
    {
        /*if (currentItems >= maxItems)
        {
            Debug.Log("Inventory is full");
            return;
        }

        items[currentItems] = item;
        currentItems++;*/
    }
}
