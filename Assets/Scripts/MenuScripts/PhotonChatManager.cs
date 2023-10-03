using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    #region Setup
    ChatClient chatClient;
    bool isConnected;
    [SerializeField] string username;
    [SerializeField] GameObject chatPanel;
    string currentChat;
    [SerializeField] TMP_InputField chatField;
    [SerializeField] TextMeshProUGUI chatDisplay;

    private bool isInputFieldActive = false; // Added variable to track input field state

    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            ConnectToChat();
        }
    }

    void Update()
    {
        if (isConnected)
        {
            chatClient.Service();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleInputField();
            // Toggle the input field visibility when Enter is pressed
        }

        if (isInputFieldActive && chatField.text != "" && Input.GetKey(KeyCode.Return))
        {
            SubmitPublicChatOnClick(); // Submit the chat message when input field is active and Enter is pressed
        }
    }

    void ToggleInputField()
    {
        isInputFieldActive = !isInputFieldActive;

        if (isInputFieldActive)
        {
            chatField.gameObject.SetActive(true);
            chatField.ActivateInputField();
        }
        else
        {
            chatField.gameObject.SetActive(false);
        }
    }

    private void ConnectToChat()
    {
        isConnected = true;
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
        Debug.Log("Connecting to chat...");
    }
    #endregion Setup

    #region PublicChat
    public void SubmitPublicChatOnClick()
    {
        chatClient.PublishMessage("RegionChannel", chatField.text);
        chatField.text = "";
        currentChat = "";
        Debug.Log("SubmitPublicChatOnClick called");

    }


    public void TypeChatOnValueChange(string valueIn)
    {
        currentChat = valueIn;
    }
    #endregion PublicChat

    #region Callbacks
    public void DebugReturn(DebugLevel level, string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        if (state == ChatState.ConnectedToFrontEnd)
        {
            Debug.Log("Connected to chat");
            chatClient.Subscribe(new string[] { "RegionChannel" });
        }
        else if (state == ChatState.Disconnected)
        {
            isConnected = false;
            chatPanel.SetActive(false);
        }
    }

    public void OnConnected()
    {
        // This method is not needed in this modified version
    }

    public void OnDisconnected()
    {
        isConnected = false;
        chatPanel.SetActive(false);
    }


    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            string senderAndMessage = $"{senders[i]}: {messages[i]}";
            chatDisplay.text += "\n" + senderAndMessage;
            Debug.Log(senderAndMessage);
        }
    }









    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        // No need for additional logic here
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }
    #endregion Callbacks
}
