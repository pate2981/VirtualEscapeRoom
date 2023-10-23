using UnityEngine;

public class Key : Item
{

    [SerializeField]
    private InventoryUI inventoryUI;

    public override object Use()
    {
        inventoryUI.OpenChest();
        return base.Use();
    }
}
