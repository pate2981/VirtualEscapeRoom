using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class LeaveRoom : MonoBehaviour
{

    public float timeRemaining = 10; // Set the initial time remaining
    public Text timerText; // Reference to the UI text element that will display the timer
    public GameObject winnerScreen;
    public GameObject toolbar;
    public GameObject crosshair;
    private bool isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.name == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            isGameOver = true;
            Time.timeScale = 0f; // Set the game time scale to 0 to stop the game
            winnerScreen.SetActive(true);
            timerText.text = "";
            toolbar.SetActive(false);
            crosshair.SetActive(false);
        }
    }
}
