using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip ninja, ninjaDie, finishgame;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ninjaSound()
    {
        source.clip = ninja;
        source.Play();
    }

    public void ninjaDiedSound()
    {
        source.clip = ninjaDie;
        source.Play();
    }

    public void FinishGameSound()
    {
        source.clip = finishgame;
        source.Play();
    }
}
