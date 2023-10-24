using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Orbsync : MonoBehaviourPun, IPunObservable
{

    private PhotonView photonView;
    [SerializeField] private GameObject pedestal1;
    [SerializeField] private GameObject pedestal2;

    public  bool deposited2 = false;

    // Start is called before the first frame update
    void Start()
    {

        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    public void orbSync()
    {
        
        photonView.RPC("EnableOrb", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void EnableOrb()
    {
        Debug.Log("EnableOrb is called");
        gameObject.SetActive(true);
        
        gameObject.transform.position = pedestal2.transform.position + new Vector3(0, 0.5f, 0);
        deposited2 = true;
       
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }

    
}
