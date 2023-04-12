using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
    }

    public void ClickNextButton()
    {
        Debug.Log("Next button clicked");
        popup.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
