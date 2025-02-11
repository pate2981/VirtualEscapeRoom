using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
   // public PhotonView cameraPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room successfully");
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
       // PhotonNetwork.Instantiate(cameraPrefab.name, Vector3.zero, Quaternion.identity);
    }
}
