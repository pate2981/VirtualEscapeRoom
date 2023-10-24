using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChestAnimation : MonoBehaviourPun, IPunObservable
{

    private Animator animator;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    public void ChestAnim()
    {
        
        gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
       
        photonView.RPC("NetworkTrigger", RpcTarget.AllViaServer);
        
    }

    [PunRPC]
    void NetworkTrigger()
    {
        Debug.Log("Trigger method is being called");
        // Trigger the animation on all clients over the network
        animator.enabled = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }
}
