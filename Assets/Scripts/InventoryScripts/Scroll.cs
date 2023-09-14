using UnityEngine;

public class Scroll : Item
{
    [SerializeField]
    private string message; // Hint contained in the scroll

    public string Message
    {
        get { return message; }
        set { message = value; }
    }
}
