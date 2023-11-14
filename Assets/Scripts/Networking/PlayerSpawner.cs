using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    //[SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    //[SerializeField] private bool isSinglePlayer;
    private Player player; 


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("PlayerSpawner Start() method called");
        Debug.Log("playerPrefabs array index: " + (int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]);
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        Debug.Log("playerPrefabs array index: " + (int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]);
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        Debug.Log("playerToSpawn" + playerToSpawn);
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);

            //TextMeshProUGUI playerNickname = playerPrefab.GetComponent<TextMeshProUGUI>();
           
            //playerNickname.text = (string)PhotonNetwork.PlayerList[0].CustomProperties["nickname"];
    }

    /*    public void CheckIsSinglePlayer(bool isSinglePlayer)
        {
            isSinglePlayer = this.isSinglePlayer;
        }*/
}
