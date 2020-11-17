/**
 *  Removes the object script is attached to once an elapse time has passed.
 *  The timer may not be precise but it will do the job.
 * 
 * 
**/

// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public double timer; // In seconds

    // Start is called before the first frame update
    void Start()
    {
        // timer = 120; // In seconds   
    }

    // Update is called once per frame
    void Update()
    {
        // We need to comensate for frame rate rendering
        // Time.deltaTime returns the amount of time that elapsed since the last frame completed.
        timer -= Time.deltaTime;
        // UnityEngine.Debug.Log(timer);

        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
