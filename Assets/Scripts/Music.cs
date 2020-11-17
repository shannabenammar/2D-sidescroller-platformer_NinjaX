using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Music : AudioSetter
{
    // Makes it so that music will play even between scenes
    // Overloads AudioSetter's Start funcion
    public static Music instance;

    void Start()
    {
        // We need this so we dont generate a billion Music objects
        // Shamelessly stolen from the Flappy Bird project
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; //Then we set our singleton to this instance
        }
        DontDestroyOnLoad(Audio);
        // UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Music")); //Debugging Audio value
        // UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Volume"));
    }
}
