using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinalBookShelfAnimation : MonoBehaviourPun, IPunObservable
{
    
    private Animator animator;
    private PhotonView photonView;
    [SerializeField] private Orbsync orbsync;
    [SerializeField] private OrbOneSync orbOneSync;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(orbsync.deposited2 == true && orbOneSync.deposited1 == true)
        {
            Debug.Log("Condition is met");
            photonView.RPC("NetworkTrigger", RpcTarget.AllViaServer);
        }
    }

    [PunRPC]
    void NetworkTrigger()
    {
        Debug.Log("Trigger is activated");
        Debug.Log("Trigger method is being called");
        // Trigger the animation on all clients over the network
        animator.SetTrigger("Trigger");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }
}
