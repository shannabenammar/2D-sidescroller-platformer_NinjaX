/**
 * To return to main menu
 * and pause game
**/

// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Gives us access to load scenes/levels

//Go back to Main Menu
public class QuitButton : MonoBehaviour
{
    public GameObject PauseUI;
    //public GameObject GameUI;

    public void quit()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {

        Time.timeScale = 0;
        PauseUI.SetActive(true);
       // GameUI.SetActive(false);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        //GameUI.SetActive(true);
    }
}