using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]

public class DragAndDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Camera myCamera;

    private void Awake()
    {
        myCamera = GameObject.Find("PlayerCam").GetComponent<Camera>();
    }

    void OnMouseDown()
    {
        screenPoint = myCamera.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - myCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = myCamera.ScreenToWorldPoint(curScreenPoint) + offset;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, curPosition - transform.position, out hit, Vector3.Distance(curPosition, transform.position)))
        {
            if (hit.collider.gameObject != gameObject)
            {
                return;
            }
        }

        transform.position = curPosition;

    }
}
