using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject HUD;
    public GameObject GameOverCanvas;
    public Text TimeVal;

    private double time;
    private int score;

    void Start()
    {
        time = 0;
    }

    //Flip over to gameover canvas
    void gameOver()
    {
        HUD.SetActive(false);
        GameOverCanvas.SetActive(true);
        UpdateText();
    }

    // Give text objects in canvas some values
    private void UpdateText()
    {
        TimeVal.text = time.ToString();
    }

    void Update()
    {
        time += Time.deltaTime;
    }
}