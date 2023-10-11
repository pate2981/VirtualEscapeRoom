/*using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.UIElements;

public class PopupMessage : MonoBehaviour
{
    public GameObject popupMessagePrefab;
    void Start()
    {
        GameObject popupMessage = Instantiate(popupMessagePrefab);
        popupMessage.transform.SetParent(transform); 
    }

    public void setMessage(string message)
    {
        RectTransform canvas = popupMessagePrefab.GetComponent<RectTransform>();
        TextMeshProUGUI text = canvas.GetComponent<TextMeshProUGUI>();

        if (text != null)
        {
            text.text = message;
            text.fontSize= 18;
            Debug.Log(message + "Popup displayed");
        }
    }

    public void CloseButton()
    {
        popupMessagePrefab.SetActive(false); // Hides the popupbox 
        //Cursor.lockState = CursorLockMode.Locked;   // Makes Pointer visible
    }
}
*/