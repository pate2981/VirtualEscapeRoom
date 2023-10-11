using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // This script manages the main menu interactions and scene transitions.

    // Starts single player game
    public void GameStart(){
        SceneManager.LoadScene(4);
    }

    // Opens credit menu by loading the credits scene
    public void CreditMenu(){
        SceneManager.LoadScene(3);
    }

    // Go back to menu
    IEnumerator BackToMain(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);

    }

    // Quits the game
    public void QuitGame(){
        Application.Quit();
    
    }
}
