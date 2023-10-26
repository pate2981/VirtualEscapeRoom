using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Photon.Voice.Unity;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField createRoomInputField;  // InputField for entering the room name 
    [SerializeField] private Toggle toggle; // Toggle for private option
    [SerializeField] private TMP_Dropdown dropdown; // Dropdown for room size

    [SerializeField] private InputField joinRoomInputField;   // Second input field
    [SerializeField] private GameObject lobbyPanel;   //  Panel for creating a room
    [SerializeField] private GameObject roomPanel;    // Panel for displaying all rooms
    [SerializeField] private TextMeshProUGUI roomName;   // Name of the room

    [SerializeField] private RoomItem RoomItemPrefab; // Prefab of the name of the room
    [SerializeField] private List<RoomItem> roomItemsList = new List<RoomItem>();    // List of RoomItem prefabs
    [SerializeField] private Transform contentObject;    // Object in scroll view that will parent RoomItems to

    private float timeBetweenUpdates = 1.5f; // Time between updates for joining rooms
    private float nextUpdateTime;
    private bool isRoomnameValid = false;
    private bool isToggled = false;
    private int maxPlayers; // stores the max players in a room

    [SerializeField] private List<PlayerItem> playerItemsList = new List<PlayerItem>();   // List of player items
    [SerializeField] private PlayerItem playerItemPrefab; // Player item prefab
    [SerializeField] private Transform playerItemParent;  // Gameobject we will parent PlayerItem to
    [SerializeField] private Transform playerAvatar;

    // Buttons for joining rooms
    [SerializeField] private Button joinMedievalBtn;    
    [SerializeField] private Button joinAsylumBtn;

    // Adds player to the lobby so that they can create rooms
    private void Start()
    {
        PhotonNetwork.JoinLobby();

        createRoomInputField.Select(); // Makes InputField ready to receive user input

        // Assign a listener to the Toggle's onValueChanged event
        toggle.onValueChanged.AddListener(delegate { Toggle(toggle); });
        toggle.isOn = false;

        // Listener to the dropdown
        dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdown);
        });
    }

    public void CreateRoom()
    {
        ValidateRoomname();
        if (isToggled== false)
        {
            if (isRoomnameValid == true)
            {
                if (maxPlayers == 1)
                {
                    PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions() { BroadcastPropsChangeToAll = true });
                    return;
                }

                PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions() { BroadcastPropsChangeToAll = true, MaxPlayers = maxPlayers });    // BroadcastProps lets Photon know that we wish to send and receive other players property changes
            }
        }
        else
        {
            if (isRoomnameValid == true)
            {
                if (maxPlayers == 1)
                {
                    PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions { BroadcastPropsChangeToAll = true, IsVisible = false});
                    return;
                }
                PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions { BroadcastPropsChangeToAll = true, IsVisible = false, MaxPlayers = maxPlayers });
            }
        }
    }

    public void Toggle(Toggle toggle)
    {
        isToggled = toggle.isOn;
    }

    public void DropdownValueChanged(TMP_Dropdown change)
    {
        maxPlayers = dropdown.value + 1;
        Debug.Log("Maxplayers = " + maxPlayers);
    }

    // Check if room name is valid
    public void ValidateRoomname()
    {
        string roomname = createRoomInputField.text.ToLower();

        // Check for empty or null room name
        if (string.IsNullOrEmpty(roomname))
        {
            Debug.Log("Room name cannot be empty");
            return;
        }

        // Trim leading and trailing whitespace
        roomname = roomname.Trim();

        // Check for special characters (allow only alphanumeric characters)
        if (!Regex.IsMatch(roomname, "^[a-zA-Z0-9 ]+$"))
        {
            Debug.Log("Room name contains special characters");
            return;
        }

        isRoomnameValid = true;
    }

    // Displays roompanel view
    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Party Name: " + PhotonNetwork.CurrentRoom.Name;

        if (maxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            PhotonNetwork.CurrentRoom.IsVisible= false;
        }

        UpdatePlayerList();
    }

    // Retrieves list of all available rooms, gets called by Photon when roomList has been changed
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            nextUpdateTime = Time.time + timeBetweenUpdates;
            UpdateRoomList(roomList);
        }
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        // Destroy all RoomItems in the scene
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        // Instantiates room item for each room available
        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(RoomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    // Joins room player has clicked on
    public void JoinRoom(string roomName)
    {
        //        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)

        // Displays the playButton to the owner of the room
        if (PhotonNetwork.IsMasterClient)
        {
            joinMedievalBtn.gameObject.SetActive(true);
            joinAsylumBtn.gameObject.SetActive(true);
        }
        // Disables the playButton to other players
        else
        {
            joinMedievalBtn.gameObject.SetActive(false);
            joinAsylumBtn.gameObject.SetActive(false);
        }

        PhotonNetwork.JoinRoom(roomName);
    }

    // Joins private room
    public void JoinPrivateRoom()
    {
        string roomName = joinRoomInputField.text;
        PhotonNetwork.JoinRoom(roomName);
    }

    /*    // test
        public void JoinAvailableRoom()
        {
            PhotonNetwork.JoinRandomOrCreateRoom();
        }*/

    // Click event for leaving the room
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    // Called by Photon when player leaves a room
    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    // Rejoins the lobby when we leave a room
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
    }

    // Updates player list GUI
    void UpdatePlayerList()
    {
        // Delete all player items
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();    // Clear PlayerItems from the list

        // Check if the room is null. If so, exit function
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        // Spawn PlayerItems for each player item in the room
        // Loops through players in a room
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent); // Instantiates PlayerItem
            newPlayerItem.SetPlayerInfo(player.Value);

            // Finds local player and applies local changes
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

            playerItemsList.Add(newPlayerItem); // Adds player to the list
        }
    }

    // Function gets called by Photon when a player enters a room
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    // Function gets called by Photon when a player leaves a room
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode)KeyBind.Next))
        {
            CreateRoom();
        }
    }

    // Loads Medieval room
    public void JoinMedievalRoom()
    {
        // Check if this is being synced
        roomName.text = "Loading Medieval Room...";
        LoadRoom();
        PhotonNetwork.LoadLevel("Medieval");
        
        // Close Room after joining
        // PhotonNetwork.CurrentRoom.IsVisibile = false;
    }

    // Load Asylum room
    public void JoinAsylumRoom()
    {
        roomName.text = "Loading Asylum Room...";
        LoadRoom();
        PhotonNetwork.LoadLevel("Asylum");
    }

    public void LoadRoom()
    {
        // Find all Button components in the scene
        Button[] allButtons = FindObjectsOfType<Button>();

        // Deactivate (set active to false) for each button
        foreach (Button button in allButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void JoinSinglePlaer()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        UpdatePlayerList();
        PhotonNetwork.LoadLevel("Medieval");
    }
}
