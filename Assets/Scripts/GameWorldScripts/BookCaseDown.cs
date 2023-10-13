using System.Collections;
using UnityEngine;
using Photon.Pun;

public class BookCaseDown : MonoBehaviourPun, IPunObservable
{
    private Animator animator;
    private PhotonView photonView;

    void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }

    public void OnMouseDown()
    {
            if (Input.GetMouseButtonDown(0))    // Check for left click
            {
                // Call a method to send the trigger over the network
                photonView.RPC("NetworkTrigger", RpcTarget.AllViaServer);
            }
    }

    [PunRPC]
    void NetworkTrigger()
    {
        // Trigger the animation on all clients over the network
        animator.SetTrigger("ActivateTrigger");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }
}
