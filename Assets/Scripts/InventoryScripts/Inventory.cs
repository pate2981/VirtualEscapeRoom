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
        // Initialize the array of outlines for the inventory slots
        slotOutlines = new Outline[inventorySlots.Length];

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Add the Outline component to each inventory slot
            slotOutlines[i] = inventorySlots[i].gameObject.AddComponent<Outline>();
            slotOutlines[i].enabled = false;
        }

        popupText.fontSize = 18;
    }

    private void Update()
    {

        // Check if the number keys 1-5 are pressed
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) || Input.GetKeyDown(KeyCode.Keypad1 + i))
            {
                // Disable the Outline component on all inventory slots
                foreach (Outline outline in slotOutlines)
                {
                    outline.enabled = false;
                }

                // Set the selected slot index to the current key index
                selectedSlotIndex = i;

                // Enable the Outline component on the selected inventory slot
                slotOutlines[i].enabled = true;
                Debug.Log("Number " + i + "clicked");
                // Set the outline color to blue
                slotOutlines[i].OutlineColor = Color.yellow;
                slotOutlines[0].OutlineWidth = 15f;

                if (selectedSlotIndex == 0)
                {
                    popupText.text = "I am surrounded by books, but I am not a librarian. I stand alone, waiting for your attention. Approach me and press F, and I will reveal to you what grants access to what you seek to seize.";
                    popupBox.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 1f;
                }
                if (selectedSlotIndex == 1)
                {
                    popupText.text = "In this room of levers, two are needed to open the way. But pull them not in haste, for they must both be in play. Listen to the sounds they make, and choose the ones that chime. For when they both are pulled, the path to freedom will be thine";
                    popupBox.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 1f;
                }
                if (selectedSlotIndex == 2)
                {
                    popupText.text = "I am a game of strategy and wit,\r\nWith two balls and pedestals, you must commit.\r\nPlace the balls just right, or you'll be stuck,\r\nFor the escape door to open, you're in luck.\r\nEach ball has its place, make no mistake,\r\nFigure out the puzzle, before it's too late.\r\nWith your mind sharp and your focus clear,\r\nThe escape is near, have no fear";
                    popupBox.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 1f;
                }
            }
        }
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
