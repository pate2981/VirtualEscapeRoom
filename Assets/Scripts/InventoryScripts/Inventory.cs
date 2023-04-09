using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int maxItems = 20;
    public int currentItems = 0;
    public Item[] items;

    private void Start()
    {
        items = new Item[maxItems];
    }

    public void AddItem(Item item)
    {
        if (currentItems >= maxItems)
        {
            Debug.Log("Inventory is full");
            return;
        }

        items[currentItems] = item;
        currentItems++;
    }
}
