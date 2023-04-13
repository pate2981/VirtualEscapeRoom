using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePed2 : MonoBehaviour
{
    public bool deposited = false;
    GameObject ped1;
    GameObject bookshelf;
    private void Start()
    {
        bookshelf = GameObject.Find("FinalBookshelf");
        ped1 = GameObject.Find("Pedestal1");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.name == "Puzzle2" && deposited == false)
        {
            deposited = true;
            collision.rigidbody.isKinematic = true;
            collision.rigidbody.transform.GetComponent<DragAndDrop>().isDraggable = false;
            collision.transform.position = collision.transform.parent.position + new Vector3(0, 1.56f, 0);
            if (ped1.GetComponentInChildren<PuzzlePed1>().deposited == true)
            {
                bookshelf.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
}
