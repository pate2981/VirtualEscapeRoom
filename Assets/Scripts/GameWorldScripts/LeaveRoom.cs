using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using Photon.Pun;

public class LeaveRoom : MonoBehaviourPun, IPunObservable
{
    public float timeRemaining = 10; // Set the initial time remaining
    public Text timerText; // Reference to the UI text element that will display the timer
    public GameObject winnerScreen;
    public GameObject toolbar;
    public GameObject crosshair;
    private bool isGameOver = false;
    //[SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        photonView.RPC("NetworkTrigger", RpcTarget.AllViaServer);

        
        
    }

    [PunRPC]
    void NetworkTrigger()
    {
        Cursor.lockState = CursorLockMode.None;
        isGameOver = true;
        Time.timeScale = 0f; // Set the game time scale to 0 to stop the game
        winnerScreen.SetActive(true);
        timerText.text = "";
        toolbar.SetActive(false);
        crosshair.SetActive(false);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }
}
