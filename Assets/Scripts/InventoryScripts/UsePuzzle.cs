/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePuzzle : MonoBehaviour
{
    public GameObject popup;
    private Inventory slotNumber;


    public void Start()
    {
        popup.SetActive(false);
    }

    public void OnMouseDown()
    {
        Debug.Log("Puzzle used!");
        int selectedSlot = slotNumber.GetSelectedSlot();
        if (selectedSlot == 1)
        {
            popup.
            popup.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
        }
    }

}
*/