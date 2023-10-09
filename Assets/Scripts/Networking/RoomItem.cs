using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI roomName;
    LobbyManager manager;   

    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>(); // Search scene for GameObject with LobbyManager script attached to it
    }

    // Sets the name of the room
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    // Click event for when a RoomItem is clicked
    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }

}
