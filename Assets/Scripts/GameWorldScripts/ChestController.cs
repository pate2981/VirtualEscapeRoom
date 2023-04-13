using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject key;
    public GameObject chest;
    public GameObject openChest;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chest and key collided");
        if (other.gameObject == key)
        {
            Debug.Log("Chest opened");
            // Instantiate the open chest object at the same position as the closed chest
            GameObject newChest = Instantiate(openChest, chest.transform.position, chest.transform.rotation);

            // Destroy the closed chest object
            Destroy(chest);

            // Destroy the key object
            Destroy(key);

            // Optional: play a sound effect or particle effect to indicate the chest opening
        }
    }
}