using UnityEngine;

public class Scroll : Item
{
    [SerializeField]
    private string message; // Hint contained in the scroll
    public InventoryUI inventoryUI;

    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    public override object Use()
    {
        inventoryUI.DisplayScroll(Message);
        return base.Use();
    }
}
