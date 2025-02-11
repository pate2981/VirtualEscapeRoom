using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject chatPanel;
    public GameObject settingsPanel;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode)KeyBind.PauseGame))
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
        //Debug.Log("Resume button pressed");
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
        chatPanel.SetActive(false);
    }

    public void SettingsBtn()
    {
        pauseMenuUI.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BacktoPauseFromSettings()
    {
        pauseMenuUI.SetActive(true);
        settingsPanel.SetActive(false);
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

    // This code is already in Menu script
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainLobby()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(1);  // Goes back to main lobby
    }
}
