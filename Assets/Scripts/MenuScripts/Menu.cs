using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // This script manages the main menu interactions and scene transitions.

    [SerializeField] private GameObject chatManager;
    [SerializeField] private GameObject voiceManager;

    // Starts single player game
    public void GameStart(){
        //SceneManager.LoadScene(2);    // 4
        PhotonNetwork.LoadLevel("Medieval");

        //PlayerSpawner playerSpawner = GetComponent<PlayerSpawner>();

        /*PhotonView photonView = playerPrefab.GetComponent<PhotonView>();
        PhotonTransformViewClassic photonTransformViewClassic = playerPrefab.GetComponent<PhotonTransformViewClassic>();
        Destroy(photonView);
        Destroy(photonTransformViewClassic);*/
        // Destroy chat manager, voice manager and voice logger and the players speaker
        //Destroy(chatManager);
        //Destroy(voiceManager);
    }

    // Opens credit menu by loading the credits scene
    public void CreditMenu(){
        SceneManager.LoadScene(3);
    }

    // Go back to menu
    IEnumerator BackToMain(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);

    }

    // Quits the game
    public void QuitGame(){
        Application.Quit();
    
    }
}
