using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.Purchasing;
using System.Text.RegularExpressions;
using System.Linq;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField usernameInput;    // InputField to enter nickname
    [SerializeField] private TextMeshProUGUI buttonText; // Button to connect to server
    private bool internetConnection = false;
    private bool isNicknameValid = false;
    //public GameObject popupMessagePrefab;

    private void Start()
    {
        usernameInput.Select(); // Makes InputField ready to receive user input
    }

    // Connects user to server
    public void OnClickConnect()
    {
        CheckInternetConnectivity();
        ValidateNickname();
        if (isNicknameValid == true && internetConnection == true)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;    // Sync scene with room owner
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

    // Check if nickname is valid
    public void ValidateNickname()
    {
        string nickname = usernameInput.text.ToLower();

        // Check for empty or null nickname
        if (string.IsNullOrEmpty(nickname))
        {
            Debug.Log("Nickname cannot be empty");
            return;
        }

        // Trim leading and trailing whitespace
        nickname = nickname.Trim();

        // Check for special characters (allow only alphanumeric characters)
        if (!Regex.IsMatch(nickname, "^[a-zA-Z0-9 ]+$"))
        {
            Debug.Log("Nickname contains special characters");
            return;
        }

        // Check nickname uniqueness
        if (!IsNicknameUnique(nickname))
        {
            Debug.Log("Nickname is already taken.");
            return;
        }
        isNicknameValid = true;
    }

    // Check if the nickname is unique within the Photon Network
    private bool IsNicknameUnique(string nickname)
    {
        // Get all Player objects in the Photon network and convert to an array
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList.ToArray();

        // Check if the nickname is already taken by another player
        return players.All(player => player.NickName.ToLower() != nickname);
    }

    // Checks if user is connected to the internet
    private void CheckInternetConnectivity()
    {
        NetworkReachability reachability = Application.internetReachability;

        if (reachability != NetworkReachability.NotReachable)
        {
            // If reachable via any means (Mobile, WiFi, LAN), allow joining
            internetConnection = true;
        }
        else
        {
            Debug.Log("Please connect to the internet to join");
        }
    }

    // Loads Lobby scene
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode)KeyBind.Next))
        {
            OnClickConnect();
        }
    }
}
