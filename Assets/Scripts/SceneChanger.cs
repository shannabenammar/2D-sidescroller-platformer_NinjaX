using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Gives us access to load scenes/levels

//Quick and dirty way to get ui going
public class SceneChanger : MonoBehaviour
{
    public string gameScene;
    public string settingScene;
    public GameObject ButtonGroup;
    public GameObject ninja;
    public GameObject HelpUI;
    public float speed;

    public void loadGame()
    {
        
    }
    public void loadSetting()
    {
        SceneManager.LoadScene(settingScene);
    }
    //Load or unload the help UI
    public void helpButton()
    {
        if (HelpUI.activeSelf)
        { //Hide Help UI elements
            HelpUI.SetActive(false);
            ButtonGroup.SetActive(true);
        } else
        {// Hide main menu elements
            HelpUI.SetActive(true);
            ButtonGroup.SetActive(false);
        }
    }
    //terminate program
    public void exit()
    {
        Debug.Log("Terminate Game...");
        Application.Quit();//Ignored in editor
    }
    public void OnGameStart()
    {
        ButtonGroup.SetActive(false);
    }
    //Animation played on pressing play button.
    public void ninjaMove()
    {
        ninja.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed ;
    }
    
    void Update()
    {
        if (ninja.transform.position.x > 10)
        {
            SceneManager.LoadScene(gameScene);
        }
    }

}

/**
 * wanted to try something but it didn't seem to work
public class SceneObject
{
    private string sceneName;
    public SceneObject(string s)
    {
        sceneName = s;
    }
    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
**/