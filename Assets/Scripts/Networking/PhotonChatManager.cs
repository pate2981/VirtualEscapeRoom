using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
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
    //[SerializeField] string username;
    [SerializeField] GameObject chatPanel;
    string currentChat;
    [SerializeField] TMP_InputField chatField;
    [SerializeField] TextMeshProUGUI chatDisplay;

    private bool isChatPanelActive = false; // Added variable to track input field state
    private string channelName = PhotonNetwork.CurrentRoom.Name;

    void Start()
    {
        chatPanel.SetActive(true);
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

        if (isChatPanelActive && chatField.text != "" && Input.GetKey((KeyCode)KeyBind.ToggleChat))
        {
            SubmitPublicChatOnClick(); // Submit the chat message when input field is active and Enter is pressed
            chatField.ActivateInputField();
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleChatPanel();
            // Toggle the input field visibility when Enter is pressed
        }
    }

    void ToggleChatPanel()
    {
        isChatPanelActive = !isChatPanelActive;

        if (isChatPanelActive)
        {
            chatPanel.gameObject.SetActive(true);
            chatField.ActivateInputField();
        }
        else
        {
            chatPanel.gameObject.SetActive(false);
        }
    }


    private void ConnectToChat()
    {
        isConnected = true;
        // Use a unique channel name for each room
        string channelName = "Room_" + PhotonNetwork.CurrentRoom.Name;
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
        chatClient.Subscribe(new string[] { channelName });
    }
    #endregion Setup

    #region PublicChat
    public void SubmitPublicChatOnClick()
    {
        chatClient.PublishMessage(channelName, chatField.text);
        chatField.text = "";
        currentChat = "";
        chatField.Select();
    }


    public void TypeChatOnValueChange(string valueIn)
    {
        currentChat = valueIn;
    }
    #endregion PublicChat

    #region Callbacks
    public void DebugReturn(DebugLevel level, string message)
    {
    }

    public void OnChatStateChange(ChatState state)
    {
        if (state == ChatState.ConnectedToFrontEnd)
        {
            //Debug.Log("Connected to chat");
            chatClient.Subscribe(new string[] { channelName });
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
        Debug.Log("OnGetMessages received msg from: " + channelName);
        for (int i = 0; i < senders.Length; i++)
        {
            string senderAndMessage = $"{senders[i]}: {messages[i]}";
            chatDisplay.text += "\n" + senderAndMessage;
            Debug.Log("Message: " + senderAndMessage);
        }
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
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
