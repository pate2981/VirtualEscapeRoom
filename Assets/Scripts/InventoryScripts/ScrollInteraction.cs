using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ScrollInteraction : MonoBehaviourPun
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private InventoryUI inventoryUI;
    public void OnMouseDown()
    {
        Debug.Log("Sroll clicked by: " + PhotonNetwork.NickName);
        // Gets the Scroll
        Scroll scroll = GetComponent<Scroll>();

        // Adds the scroll to the player's inventory
        inventoryManager.AddItem(scroll);

        // Call an RPC to remove the visibility of scroll object from the game world for all players
        photonView.RPC("DisableScroll", RpcTarget.AllBuffered);

        inventoryUI.DisplayScroll(scroll.Message);
    }

    [PunRPC]
    private void DisableScroll()
    {
        gameObject.SetActive(false);
    }
}
