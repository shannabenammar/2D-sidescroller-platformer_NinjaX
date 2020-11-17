using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDeath : MonoBehaviour
{
    public GameObject Ninja;
    public GameObject GameOver;
    void Awake()
    {
        Kill.onKill += OnDeath;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDeath()
    {
       

        GameOver.SetActive(true);
    }
    void OnDestroy()
    {
        Kill.onKill -= OnDeath;
    }

}
