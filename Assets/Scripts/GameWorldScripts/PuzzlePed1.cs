using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePed1 : MonoBehaviour
{
    public bool deposited = false;
    GameObject ped2;
    GameObject bookshelf;
    private void Start()
    {
        bookshelf = GameObject.Find("FinalBookshelf");
        ped2 = GameObject.Find("Pedestal2");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.name == "Puzzle1" && deposited == false)
        {
            deposited = true;
            collision.rigidbody.isKinematic = true;
            collision.rigidbody.transform.GetComponent<DragAndDrop>().isDraggable = false;
            collision.transform.position = collision.transform.parent.position + new Vector3(0, 1.56f, 0);

            if(ped2.GetComponentInChildren<PuzzlePed2>().deposited == true)
            {
                bookshelf.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
}
