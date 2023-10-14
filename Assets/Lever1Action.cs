using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Lever1Action : MonoBehaviourPun, IPunObservable
{
    private Animator animator;
    private PhotonView photonView;
    [SerializeField]
    private GameObject bookcaseRotate;

    void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
        bookcaseRotate = GameObject.Find("BookcaseDoor");
        
    }

    public void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))    // Check for left click
        {
            Debug.Log("Click Works");
            // Call a method to send the trigger over the network
            photonView.RPC("NetworkTrigger", RpcTarget.AllViaServer);
        }
    }

    [PunRPC]
    void NetworkTrigger()
    {
        // Trigger the animation on all clients over the network

        animator.SetTrigger("Trigger");

        
        LeverActivate leverActivate2 = GameObject.Find("LeverObj2").GetComponent<LeverActivate>();

          
        
        if (leverActivate2.Activated == true)
        {
             leverActivate2.Activated = false;
        }
        else
        {
             leverActivate2.Activated = true;
        }

        Debug.Log("LeverObj2 is true");
        
        bookcaseRotate.GetComponent<BookcaseDoorMove>().updated();


    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }
}
