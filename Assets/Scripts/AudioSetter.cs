using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetter : MonoBehaviour
{
    //the key we want to access from PlayerPrefs
    public string key;
    private float volume;
    private float masterVol;
    protected AudioSource Audio;
    //public Text temp; //For debugging purposes.

    // Start is called before the first frame update
    void Awake()
    {
        Audio = gameObject.GetComponent<AudioSource>(); //Self reference to what script is attached to.
        //temp = gameObject.GetComponent(typeof(Text)) as GameObject.Find("Text_Music_Val");
        volume = PlayerPrefs.GetFloat(key); //Init volume
        Audio.volume = volume;
    }

    void Start()
    {
 
    }


    // Update is called once per frame
    // Here we would adjust volume to settings
    // Remember to limit values to range of 0.00 to 1.00
    // You can accomplish this by dividing by 100 since settings sets those values from 0 to 100
    void Update()
    {
        //Audio.volume = Convert.ToSingle(temp.text)/100; //For debugging purposes.

        //Update only if changed
        if (volume != PlayerPrefs.GetFloat(key))
        {
            volume = PlayerPrefs.GetFloat(key);
            Audio.volume = volume;
        }
    }
}
