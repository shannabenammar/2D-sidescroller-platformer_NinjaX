using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public static int hitpoints;

    // Start is called before the first frame update
    void Start(){
        hitpoints = 100;
    }

    // Update is called once per frame
    void Update(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;  

        if(hitpoints <= 0) {
            Debug.Log("Player dies");
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
    }

    void Attack() {
        // Play atk anim
        // detect in range enemy
        // damage them
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.name.Equals("Tony")){
            hitpoints -= 30;
        }
    }
}
