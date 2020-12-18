using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject ninja;
    public float speed;
    public void ninjaMove(){
        ninja.GetComponent<Rigidbody2D>().velocity = new Vector2(100.0f, 0.0f) * speed;
    } 
}
