using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Transform playerCam;
    public float playerActivateDistance;
    bool active = false;
    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(playerCam.position, playerCam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        if (Input.GetKeyDown(KeyCode.F) && active == true)
        {
            if (hit.transform.name == "Door")
            {
                hit.transform.parent.GetComponent<Animator>().SetTrigger("Activate");
            }

            if(hit.transform.name == "ButtonMove")
            {
                hit.transform.GetComponent<Animator>().SetTrigger("Activate");
                hit.transform.parent.parent.parent.Find("BlockMove").transform.GetComponent<Animator>().SetTrigger("Activate");
            }
        }
    }
}
