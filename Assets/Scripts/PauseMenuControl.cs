using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    public GameObject pauseMenuUI;

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Resume button pressed");
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        StartCoroutine(PauseCoroutine());
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
