using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleChest : MonoBehaviour
{
    private bool deposited = false;
    public AudioSource chestOpenSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.name == "Key" && deposited == false)
        {
            chestOpenSound.Play();
            deposited = true;
            GameObject.Find("Chest").GetComponent<Animator>().enabled = true;
            GameObject.Find("Chest").GetComponentInChildren<MeshCollider>().enabled = false;
            collision.gameObject.SetActive(false);
        }
    }
}
