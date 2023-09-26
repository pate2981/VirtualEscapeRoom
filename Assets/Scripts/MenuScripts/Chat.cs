using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public GameObject chatPanel;
    public InputField chatInputField;
    public Text chatText; // Text area to display chat messages

    private bool isChatOpen = false;

    private void Start()
    {
        chatPanel.SetActive(false);
    }

    private void Update()
    {
        // Toggle chat UI on Enter key press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleChat();
        }
    }

    private void ToggleChat()
    {
        isChatOpen = !isChatOpen;
        chatPanel.SetActive(isChatOpen);

        if (isChatOpen)
        {
            // Set focus to the chat input field when opening the chat
            chatInputField.Select();
            chatInputField.ActivateInputField();
        }
        else
        {
            // Clear the input field when closing the chat
            chatInputField.text = "";
            chatInputField.DeactivateInputField();
        }
    }

    public void AddChatMessage(string message)
    {
        // Add the chat message to the text area
        chatText.text += message + "\n";
    }
}