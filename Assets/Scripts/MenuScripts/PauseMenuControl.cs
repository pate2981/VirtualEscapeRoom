using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuControl : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Text timerText; 
    public GameObject toolbar;
    public GameObject crosshair;
    public GameObject gameOver;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Resume button pressed");
        toolbar.SetActive(true);
        crosshair.SetActive(true);
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        isPaused = true;
        StartCoroutine(PauseCoroutine());
        timerText.text = "";
        toolbar.SetActive(false);
        crosshair.SetActive(false);
    }

    private IEnumerator PauseCoroutine()
    {
        float previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        while (isPaused)
        {
            yield return null;
        }

        Time.timeScale = previousTimeScale;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Menu button pressed");
    }
}
