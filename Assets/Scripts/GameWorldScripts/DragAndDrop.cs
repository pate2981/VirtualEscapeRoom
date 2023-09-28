using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(MeshCollider))]

public class DragAndDrop : MonoBehaviourPunCallbacks
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public PhotonView playerPrefab;
    private Camera myCamera;
    public bool dragged = false;
    public bool isDraggable = true;
    private void Awake()
    {
        Debug.Log("Awake beginning");

        if (playerPrefab == null)
        {
            Debug.Log("Player not found");

        }

        else
        {
            Debug.Log("Player Prefab is picked up");
            Transform playerCamTransform = playerPrefab.transform.Find("PlayerCam");

            if (playerCamTransform == null)
            {
                Debug.LogError("PlayerCam not Found");
            }
            else
            {
                myCamera = playerCamTransform.GetComponent<Camera>();

                if (myCamera != null)
                {
                    Debug.Log("Camera found: " + myCamera.name);
                }
                else
                {
                    Debug.LogError("Camera component not found on PlayerCam");
                }
            }
        }

        if (myCamera == null)
        {
            Debug.LogError("Camera not found. Make sure the camera GameObject exists and is named correctly.");
        }
    }

    void OnMouseDown()
    {
        screenPoint = myCamera.WorldToScreenPoint(gameObject.transform.position);
        Debug.LogError("Initial position " + gameObject.transform.position);
        offset = gameObject.transform.position - myCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        dragged = true;
        if (this.GetComponent<Rigidbody>().isKinematic == true)
            this.GetComponent<Rigidbody>().isKinematic = false;

        Debug.LogError("MouseDown Working");
    }

    private void OnMouseUp()
    {
        dragged = false;

        Debug.Log("MouseUp Working");

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = myCamera.ScreenToWorldPoint(curScreenPoint) + offset;

        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(myCamera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // Log information about the hit
            Debug.Log("Hit object name: " + hit.collider.gameObject.name);

            // Check if the hit object is the same as the GameObject being dragged
            if (hit.collider.gameObject == gameObject)
            {
                // The ray hit the GameObject that is being dragged
                // You can add your drag logic here
                transform.position = curPosition;
            }
        }
        else
        {
            Debug.Log("No hit detected.");
        }
    }


}



