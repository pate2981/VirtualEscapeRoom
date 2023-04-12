using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public GameObject keyImage;
    public GameObject keyPrefab;
    public GameObject inventorySlot;
    public GameObject popup;

    public void Start()
    {
        popup.SetActive(false);
        //Time.timeScale = 0f;
    }

    public void OnMouseDown()
    {
        Debug.Log("Puzzle found!");

        // Instantiate the prefab as a child of the canvas
        GameObject newObject = Instantiate(keyImage, inventorySlot.transform);
        newObject.transform.localPosition = Vector3.zero;
        keyPrefab.SetActive(false);
        popup.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    public void UsePuzzle()
    {
        Debug.Log("Puzzle used!");
    }

}
