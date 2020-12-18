using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Gives us access to load scenes/levels

//Quick and dirty way to get ui going
public class SceneChanger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            SceneManager.LoadScene("Game Scene");
        }
    }
}