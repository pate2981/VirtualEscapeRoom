using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OrbOneSync : MonoBehaviourPun, IPunObservable
{

    private PhotonView photonView;
    [SerializeField] private GameObject pedestal1;
    [SerializeField] private GameObject pedestal2;
    public  bool deposited1 = false;
    

    // Start is called before the first frame update
    void Start()
    {

        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    public void orbOneSync()
    {

        photonView.RPC("EnableOrb1", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void EnableOrb1()
    {
        Debug.Log("EnableOrb1 is called");
        gameObject.SetActive(true);

        gameObject.transform.position = pedestal1.transform.position + new Vector3(0, 0.5f, 0);
        deposited1 = true;

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // No need to send any data here as we're only using a trigger
    }


}
