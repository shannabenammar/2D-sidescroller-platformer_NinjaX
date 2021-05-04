using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update(){

    }
   
    void OnCollisionEnter2D(Collision2D coll){

    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        
        if(hitInfo.name == "FloorCollider"){
            rb.angularVelocity = 0f;
            rb.velocity = new Vector2(0f, 0f);
            rb.Sleep();
            
        }

        if(hitInfo.name == "Bat") {
            ScoreScript.scoreValue += 1;
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }
    }
}
