using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePed1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.name == "Puzzle1")
        Debug.Log("Collision");
    }
}
