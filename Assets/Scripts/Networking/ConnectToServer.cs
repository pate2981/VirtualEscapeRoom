using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.Purchasing;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField usernameInput;    // InputField to enter nickname
    [SerializeField]
    private TextMeshProUGUI buttonText; // Button to connect to server
    [SerializeField]
    private bool internetConnection = false;
    //public GameObject popupMessagePrefab;

    private void Start()
    {
        usernameInput.Select(); // Makes InputField ready to receive user input
    }

    // Connects user to server
    public void OnClickConnect()
    {
        CheckInternetConnectivity();
        if (usernameInput.text.Length >= 1 && internetConnection == true)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;    // Sync room owner... 
            PhotonNetwork.ConnectUsingSettings();   // Connects user to Photon server
        }
        else
        {
            /*PopupMessage popupMessageScript = popupMessagePrefab.GetComponent<PopupMessage>();

            if (popupMessageScript != null)
            {
                popupMessageScript.setMessage("Please connect to the internet");
            }*/
        }
    }

    // Checks if user is connected to the internet
    private void CheckInternetConnectivity()
    {
        NetworkReachability reachability = Application.internetReachability;
        switch (reachability)
        {
            case NetworkReachability.NotReachable:
                Debug.Log("Please connect to the internet to join");
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                internetConnection= true;
                break;
        }
    }

    // Loads Lobby scene
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
