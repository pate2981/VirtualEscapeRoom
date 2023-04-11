using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Transform playerCam;
    public float playerActivateDistance;
    GameObject bookcaseRotate;
    bool active = false;

    private void Start()
    {
        bookcaseRotate = GameObject.Find("BookcaseDoor");
    }
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

            if (hit.transform.name == "ButtonMove")
            {
                hit.transform.GetComponent<Animator>().SetTrigger("Activate");
                hit.transform.parent.parent.parent.Find("BlockMove").transform.GetComponent<Animator>().SetTrigger("Activate");
            }

            if (hit.transform.name == "BookcaseMove")
            {
                hit.transform.GetComponent<Animator>().SetTrigger("ActivateTrigger");
            }

            if (hit.transform.name == "LeverHandle")
            {
                hit.transform.parent.GetComponent<Animator>().SetTrigger("Trigger");
                if (hit.transform.parent.parent.GetComponent<LeverActivate>().Activated == true)
                    hit.transform.parent.parent.GetComponent<LeverActivate>().Activated = false;
                else
                    hit.transform.parent.parent.GetComponent<LeverActivate>().Activated = true;
                bookcaseRotate.GetComponent<BookcaseDoorMove>().updated();
            }
            if (hit.transform.name == "Key")
            {
                Debug.Log("Key clicked");
            }
        }
    }
}