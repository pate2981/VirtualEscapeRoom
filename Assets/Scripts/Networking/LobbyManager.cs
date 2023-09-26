using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;  // InputField for entering the room name 
    // Test
    public InputField roomNameInputField;   // Testing second input field
    public GameObject lobbyPanel;   //  Panel for creating a room
    public GameObject roomPanel;    // Panel for displaying all rooms
    public Text roomName;   // Name of the room

    public RoomItem RoomItemPrefab; // Prefab of the name of the room
    List<RoomItem> roomItemsList = new List<RoomItem>();    // List of RoomItem prefabs
    public Transform contentObject;    // Object in scroll view that will parent RoomItems to

    //public float timeBetweenUpdates = 1.5f; // Time between updates for joining rooms
    //float nextUpdateTime;

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();   // List of player items
    public PlayerItem playerItemPrefab; // Player item prefab
    public Transform playerItemParent;  // Gameobject we will parent PlayerItem to

    public GameObject playButton;

    // Adds player to the lobby so that they can create rooms
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    // Creates room based on name inputted
    public void OnClickCreate()
    {
        // Room name should not be empty
        if (roomInputField.text.Length >= 1)
        {
            // BroadcastProps lets Photon know that we wish to send and receive other players property changes
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { BroadcastPropsChangeToAll = true});
            Debug.Log(PhotonNetwork.CurrentRoom);
            Debug.Log("Are we in a room? " + PhotonNetwork.InRoom);            // This line sets the max players for a room to 3
            // PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 3});
        }
    }

    // Displays roompanel view
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    // Retrieves list of all available rooms, get called by Photon when roomList has been changed
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //if (Time.time >= nextUpdateTime)
        //{
          //  Debug.Log("OnRoomListUpdated called");
            UpdateRoomList(roomList);
            //nextUpdateTime= Time.time + timeBetweenUpdates;
        //}
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
        PhotonNetwork.JoinRoom(roomName);
    }

    // test
    public void JoinRoom()
    {
        string roomName = roomNameInputField.text;
        PhotonNetwork.JoinRoom(roomName);
        Debug.Log(PhotonNetwork.CurrentRoom);
        Debug.Log("Are we in a room? " + PhotonNetwork.InRoom);
    }

    // test
    public void JoinAvailableRoom()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    // Click event for leaving the room
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

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
//        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)

        // Displays the playButton to the owner of the room
        if (PhotonNetwork.IsMasterClient)
        {
            playButton.SetActive(true);
        }
        // Disables the playButton to other players
        else
        {
            playButton.SetActive(false);
        }
    }

    // Loads Medieval room
    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("Medieval");
    }
}
