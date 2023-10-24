using UnityEngine;

public class Orb1 : Item
{

    [SerializeField] private InventoryUI inventoryUI;

    public override object Use()
    {
        inventoryUI.PlaceOrb1();
        return base.Use();
    }
}
