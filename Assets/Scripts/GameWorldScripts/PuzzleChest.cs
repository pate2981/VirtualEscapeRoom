using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleChest : MonoBehaviour
{
    private bool deposited = false;
    private void OnCollisionEnter(Collision collision)
    public AudioSource chestOpenSound;

    {
        if(collision.rigidbody.name == "Key" && deposited == false)
        {
            chestOpenSound.Play();
            deposited = true;
            GameObject.Find("Chest").GetComponent<Animator>().enabled = true;
            GameObject.Find("Chest").GetComponentInChildren<MeshCollider>().enabled = false;
            collision.gameObject.SetActive(false);
        }
    }
}
