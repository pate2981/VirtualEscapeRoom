using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public GameObject scrollImage;
    public GameObject scrollPrefab;
    public GameObject inventorySlot;
    public GameObject popup;

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
            popup.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
    }
}
