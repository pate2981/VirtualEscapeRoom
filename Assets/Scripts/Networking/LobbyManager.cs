using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;  // InputField for entering the room name 
    public GameObject lobbyPanel;   //  Panel for creating a room
    public GameObject roomPanel;    // Panel for displaying all rooms
    public Text roomName;   // Name of the room

    public RoomItem RoomItemPrefab; // Prefab of the name of the room
    List<RoomItem> roomItemsList = new List<RoomItem>();    // List of R oomItem prefabs
    public Transform contentObject;    // Object in scroll view that will parent RoomItems to

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;

    // Adds player to the lobby so that they can create rooms
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    // Creates room based on name inputted
    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text);
            Debug.Log("Room created");

            // This line sets the max players for a room to 3
            // PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 3});
        }
    }

    // Displays roompanel view
    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }

    // Retrieves list of all available rooms
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime= Time.time + timeBetweenUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        // Destroy all room items in the scene
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

    // Joins the lobby when we leave a room
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
}
