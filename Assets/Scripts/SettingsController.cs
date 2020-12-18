using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{    
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    // public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;
    public AudioMixer audioMixer;

    void Start() {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0) {
            backgroundFloat = 0.5f;
            soundEffectsFloat = 0.5f;

            SetSound(backgroundFloat);
            SetSFX(soundEffectsFloat);

            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else {
            PlayerPrefs.GetFloat(BackgroundPref);
            SetSound(backgroundFloat);
            PlayerPrefs.GetFloat(SoundEffectsPref);             
            SetSFX(soundEffectsFloat);

        }
    }

    public void SaveSoundSettings() {
        PlayerPrefs.SetFloat(BackgroundPref, GetSound());
        PlayerPrefs.SetFloat(SoundEffectsPref, GetSFX()); 
    }

    void OnApplicationFocus(bool inFocus) {
        if(!inFocus)
            SaveSoundSettings();
    }

    public void SetSound(float volume){
        audioMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
    }

    public void SetSFX(float volume) {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    float GetSound() {
        float value;
        audioMixer.GetFloat("Sound", out value);

        Debug.Log(value);
        return value;
    }

    float GetSFX() {
        float value;
        
        audioMixer.GetFloat("SFX", out value);

        return value;
    }
}
