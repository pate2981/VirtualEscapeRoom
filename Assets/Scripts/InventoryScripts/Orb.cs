using UnityEngine;

public class Orb : Item
{

    [SerializeField] private InventoryUI inventoryUI;

    public override object Use()
    {
        inventoryUI.PlaceOrb();
        return base.Use();
    }
}
