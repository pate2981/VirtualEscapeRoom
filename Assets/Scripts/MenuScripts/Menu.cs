using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     
    public void GameStart(){
        SceneManager.LoadScene(2);
    }

    // Opens credit menu
    public void CreditMenu(){
        SceneManager.LoadScene(3);
    }

    // Go back to menu
    IEnumerator BackToMain(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
       public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    // Quits the game
    public void QuitGame(){
        Application.Quit();
    
    }
}
