/*using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public GameObject popup;
    public GameObject crosshair;

    void Start()
    {
    }

    public void CloseButton()
    {
        //Debug.Log("Next button clicked");
        
        popup.SetActive(false); // Hides the popupbox 
        Cursor.lockState = CursorLockMode.Locked;   // Makes Pointer visible
        Time.timeScale = 1f;    // Locks screen so user can read msg
        crosshair.SetActive(true);
    }
}
*/