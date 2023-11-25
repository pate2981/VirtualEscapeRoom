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
        AsylumKey key = GetComponent<AsylumKey>();

        inventoryManager.AddItem(key);

        photonView.RPC("DisableKey", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void DisableKey()
    {
        gameObject.SetActive(false);
    }
}
