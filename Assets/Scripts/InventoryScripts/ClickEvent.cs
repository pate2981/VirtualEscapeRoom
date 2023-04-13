using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public GameObject scrollImage;
    public GameObject scrollPrefab;
    public GameObject inventorySlot;
    public GameObject popup;
    //public Text popupText;

    public void Start()
    {
        popup.SetActive(false);
    }

    public void OnMouseDown()
    {
        Debug.Log("Puzzle found!");
            // Instantiate the prefab as a child of the canvas
            GameObject newObject = Instantiate(scrollImage, inventorySlot.transform);
            newObject.transform.localPosition = Vector3.zero;
            scrollPrefab.SetActive(false);
        //popupText.text = "I am surrounded by books, but I am not a librarian. I stand alone, waiting for your attention. Approach me and press F, and I will reveal to you what grants access to what you seek to seize.";
        //popup.SetActive(true);
          //  Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 1f;
    }
}
