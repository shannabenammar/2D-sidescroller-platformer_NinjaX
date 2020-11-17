/**
 * Manages all the attached game objects in the Settings Scene
 * Keep in mind that audio objects uses 0.00 to 1.00
 * 
 * Volume is bugged, wont change from 0 and no amount of holy water is going to excorcise this one for the time being.
 * The slider will be unloaded, as for the code related to it, keep it around just in case.
**/ 

using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Gives us access to load scenes/levels
using System.Diagnostics;

public class SettingsManager : MonoBehaviour
{
    
    // if only GameObject.find would play nice....
    // Setting text object
    public Text VolumeText;
    public Text SFXText;
    public Text MusicText;
    // Settings: sliders, buttons, whatever.
    public Slider VolumeSettings;
    public Slider SFXSettings;
    public Slider MusicSettings;
    public string Scene;

    // We gotta load our saved settings
    void Awake()
    {
        // Init Slider values
        // UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Volume"));
        VolumeSettings.value = PlayerPrefs.GetFloat("Volume") * 100;
        SFXSettings.value = PlayerPrefs.GetFloat("SFX") * 100;
        MusicSettings.value = PlayerPrefs.GetFloat("Music") * 100;
        updatePlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Volume"));
        //Update values of text objects only if a change occurs so as to not bog down the system.
        if (
                VolumeSettings.value != StringToFloat(VolumeText.text) ||
                SFXSettings.value != StringToFloat(SFXText.text) ||
                MusicSettings.value != StringToFloat(MusicText.text)
            )
        {
            VolumeText.text = VolumeSettings.value.ToString();
            SFXText.text = SFXSettings.value.ToString();
            MusicText.text = MusicSettings.value.ToString();
            updatePlayerPrefs();
        }
    }

    //Weird stuff happens when I tried to just use convert directly in the if statement so it's staying
    private static float StringToFloat(String s)
    {
        return Convert.ToSingle(s);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(Scene);
    }
    private void updatePlayerPrefs()
    {
        PlayerPrefs.SetFloat("volume", (VolumeSettings.value / 100));
        PlayerPrefs.SetFloat("SFX", (SFXSettings.value / 100));
        PlayerPrefs.SetFloat("Music", (MusicSettings.value / 100));
        // UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Volume"));
        PlayerPrefs.Save();
    }
}