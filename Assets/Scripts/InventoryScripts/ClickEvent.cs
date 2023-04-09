using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public GameObject keyImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Puzzle item clicked!");
    }
}
