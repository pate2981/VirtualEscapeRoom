using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsylumKey : Item
{
    [SerializeField] private InventoryUI inventoryUI;
    public override object Use()
    {
        Debug.Log("Keypad Activated");
        inventoryUI.activateKeypad();
        return base.Use();
    }
}
