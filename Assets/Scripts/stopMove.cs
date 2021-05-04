using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMove : MonoBehaviour
{
    public GameObject enemy;
    
    
    void onStop()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void Awake()
    {
        Kill.onKill += onStop;
    }
    void OnDestroy()
    {
        Kill.onKill -= onStop;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
