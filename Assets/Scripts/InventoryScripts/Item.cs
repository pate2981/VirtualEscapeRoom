using UnityEngine;

/* An item is any Game Object that can be stored in the inventory system
 */
public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;    // Name of the item

    [SerializeField]
    private GameObject image;   // Sprite representing the item

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public GameObject Image
    {
        get { return image; }
        set { image = value; }
    }
}
