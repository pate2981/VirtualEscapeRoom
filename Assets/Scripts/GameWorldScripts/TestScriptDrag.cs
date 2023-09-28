using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TestScriptDrag : MonoBehaviour
{
    Vector3 offset;
    public PhotonView playerPrefab;
    private Camera myCamera;
    private Rigidbody rb;


    private void Awake()
    {
        Debug.Log("Awake beginning");

        if (playerPrefab == null)
        {
            Debug.LogError("Player not found");

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

        rb = GetComponent<Rigidbody>();
    }



    private Vector3 GetMousePos()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = myCamera.WorldToScreenPoint(transform.position).z;
        return myCamera.ScreenToWorldPoint(mouseScreenPos);

    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMousePos();
        Debug.Log("Down Works");
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + offset;
        Debug.Log("Drag Works");
    }

    
}
