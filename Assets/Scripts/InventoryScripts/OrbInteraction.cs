using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OrbInteraction : MonoBehaviourPun
{
    [SerializeField] private InventoryManager inventoryManager;

    public void OnMouseDown()
    {
        Debug.Log("Orb clicked by: " + PhotonNetwork.NickName);
        // Gets the Scroll
        Orb orb = GetComponent<Orb>();

        // Adds the scroll to the player's inventory
        inventoryManager.AddItem(orb);

        // Call an RPC to remove the visibility of scroll object from the game world for all players
        photonView.RPC("DisableOrb", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void DisableOrb()
    {
        gameObject.SetActive(false);
    }
}
