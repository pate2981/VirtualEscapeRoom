using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour
{
    public GameObject keyImage;
    public GameObject keyPrefab;
    public GameObject inventorySlot;
    public void OnMouseDown()
    {
        Debug.Log("Puzzle found!");

        // Instantiate the prefab as a child of the canvas
        GameObject newObject = Instantiate(keyImage, inventorySlot.transform);
        newObject.transform.localPosition = Vector3.zero;
        keyPrefab.SetActive(false);
    }

    public void UsePuzzle()
    {
        Debug.Log("Puzzle used!");
    }

}
