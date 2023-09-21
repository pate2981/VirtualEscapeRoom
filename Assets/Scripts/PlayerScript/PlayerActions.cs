using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            // Moves the bookcase if the user clicks it
            if (hit.transform.name == "BookcaseMove")
            {
                hit.transform.GetComponent<Animator>().SetTrigger("ActivateTrigger");
            }

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