using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerActions : MonoBehaviourPun
{
    [SerializeField]
    private Transform playerCam;
    [SerializeField]
    private float playerActivateDistance;
    [SerializeField]
    private GameObject bookcaseRotate;
    [SerializeField]
    private bool active = false;
    
    private RaycastHit hit;

    private void Start()
    {
        bookcaseRotate = GameObject.Find("BookcaseDoor");
    }

    private void Update()
    {
        active = Physics.Raycast(playerCam.position, playerCam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);

        // Checks to see if player has left clicked on their mouse
        if (Input.GetMouseButtonDown((int)MouseButton.Left) && active == true)
        {
            if (hit.transform.name == "Door")
            {
                hit.transform.parent.GetComponent<Animator>().SetTrigger("Activate");
            }

            if (hit.transform.name == "ButtonMove")
            {
                hit.transform.GetComponent<Animator>().SetTrigger("Activate");
                hit.transform.parent.parent.parent.Find("BlockMove").transform.GetComponent<Animator>().SetTrigger("Activate");
            }

/*            // Moves the bookcase if the user clicks it
            if (hit.transform.name == "BookcaseMove")
            {
                if (photonView.IsMine)
                {
                    // Call an RPC to remove the visibility of scroll object from the game world for all players
                    photonView.RPC("MoveBookcase", RpcTarget.AllBuffered, "ActivateTrigger");
                }
            }*/

            // Triggers the lever if it is clicked
            if (hit.transform.name == "LeverHandle")
            {
                hit.transform.parent.GetComponent<Animator>().SetTrigger("Trigger");
                if (hit.transform.parent.parent.GetComponent<LeverActivate>().Activated == true)
                    hit.transform.parent.parent.GetComponent<LeverActivate>().Activated = false;
                else
                    hit.transform.parent.parent.GetComponent<LeverActivate>().Activated = true;
                bookcaseRotate.GetComponent<BookcaseDoorMove>().updated();
            }
        }
    }
}