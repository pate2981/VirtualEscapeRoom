using UnityEngine;

public class Scroll : Item
{
    [SerializeField]
    private string message; // Hint contained in the scroll
    InventoryUI inventoryUI;

    public void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }
    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    public override object Use()
    {
        Debug.Log("The message is " + Message);
        inventoryUI.DisplayScroll(Message);
        return base.Use();
    }
}
