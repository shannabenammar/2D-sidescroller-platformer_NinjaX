using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class Bat : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -25 && transform.position.x < -20)
        {
            sr.flipX = true;
        }
    }

}
