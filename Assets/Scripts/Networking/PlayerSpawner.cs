using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    // Remove this later
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private bool isSinglePlayer;


    // Start is called before the first frame update
    private void Start()
    {
        if (isSinglePlayer)
        {
            int randomNumber = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomNumber];
            Instantiate(playerPrefab, spawnPoint);
            PhotonView photonView = playerPrefab.GetComponent<PhotonView>();
            PhotonTransformViewClassic photonTransformViewClassic = playerPrefab.GetComponent<PhotonTransformViewClassic>();
            Destroy(photonView);
            Destroy(photonTransformViewClassic);
            // Destroy chat manager, voice manager and voice logger and the players speaker
        }
        else
        {
            int randomNumber = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomNumber];
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity);
            TextMeshProUGUI playerNickname = playerPrefab.GetComponent<TextMeshProUGUI>();
            playerNickname.text = PhotonNetwork.NickName;
        }
    }

    public void CheckIsSinglePlayer(bool isSinglePlayer)
    {
        isSinglePlayer = this.isSinglePlayer;
    }
}
