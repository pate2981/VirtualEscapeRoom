using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }

    public Transform cameraPosition;

    // You can also assign the cameraPosition reference in the Inspector by dragging the camera's Transform onto this field.
    private void Awake()
    {
        // Ensure there is only one instance of GameManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optionally, prevent the GameManager from being destroyed when loading scenes.
        }
        else
        {
            Destroy(gameObject); // If another GameManager exists, destroy this one.
        }
    }
}
