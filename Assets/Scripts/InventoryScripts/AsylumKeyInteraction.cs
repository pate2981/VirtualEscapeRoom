using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AsylumKeyInteraction : MonoBehaviourPun
{
    [SerializeField] private InventoryManager inventoryManager;

    public void OnMouseDown()
    {
        Debug.Log("Key clicked by: " + PhotonNetwork.NickName);
        // Gets the Scroll
        AsylumKey key = GetComponent<AsylumKey>();

        // Adds the scroll to the player's inventory
        inventoryManager.AddItem(key);

        // Call an RPC to remove the visibility of scroll object from the game world for all players
        photonView.RPC("DisableKey", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void DisableKey()
    {
        gameObject.SetActive(false);
    }
}
