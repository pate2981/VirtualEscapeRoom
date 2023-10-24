using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Orb1Interaction : MonoBehaviourPun
{
    [SerializeField] private InventoryManager inventoryManager;

    public void OnMouseDown()
    {
        Debug.Log("Orb1 clicked by: " + PhotonNetwork.NickName);
        // Gets the Scroll
        Orb1 orb1 = GetComponent<Orb1>();

        // Adds the scroll to the player's inventory
        inventoryManager.AddOrb1(orb1);

        // Call an RPC to remove the visibility of scroll object from the game world for all players
        photonView.RPC("DisableOrb1", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void DisableOrb1()
    {
        gameObject.SetActive(false);
    }
}
