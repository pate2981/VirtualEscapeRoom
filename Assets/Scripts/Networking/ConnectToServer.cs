using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;    // InputField to enter nickname
    public TextMeshProUGUI buttonText; // Button to connect to server

    // Connects user to server
    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;    // Sync room owner... 
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Loads Lobby scene
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
