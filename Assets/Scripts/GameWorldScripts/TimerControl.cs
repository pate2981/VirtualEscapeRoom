using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{

    public float timeRemaining = 10; // Set the initial time remaining
    public Text timerText; // Reference to the UI text element that will display the timer
    public GameObject gameOverScreen;

    private bool isGameOver = false;
    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(UpdateTimer()); // Start the coroutine to update the timer
    }

    private IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Subtract the time since last frame from the time remaining
            timerText.text = "Time Left: " + Mathf.RoundToInt(timeRemaining).ToString(); // Update the UI text element with the current time remaining
            yield return null;
        }
        GameOver(); // Activate the game over screen object when the time runs out
    }
    private void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        isGameOver = true;
        Time.timeScale = 0f; // Set the game time scale to 0 to stop the game
        gameOverScreen.SetActive(true); // Activate the game over screen object
    }


    public void RestartGame()
    {
        isGameOver = false;
        gameOverScreen.SetActive(false); // Deactivate the game over screen object
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene to restart the game
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu"); // Load the "MainMenu" scene to go back to the main menu
    }

}

