using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D player;

    float mx;
    public static int hitpoints;

    // Start is called before the first frame update
    void Start(){
        hitpoints = 100;
    }

    // Update is called once per frame
    void Update(){
        mx = Input.GetAxisRaw("Horizontal");
     
       if(Input.GetButtonDown("Jump")){
           Jump();
       }

        // Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        
        // //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // //transform.position += movement * Time.deltaTime * moveSpeed;  

        // if(hitpoints <= 0) {
        //     Debug.Log("Player dies");
        // }

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Attack();
        // }
    
    
    void Jump() {
        Vector2 movement = new Vector2(player.velocity.x, jumpForce);

        player.velocity = movement;
    }}

    void FixedUpdate(){
        Vector2 movement = new Vector2(mx * moveSpeed, player.velocity.y);
        player.velocity = movement;
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
        if(collider.gameObject.name.Equals("back wall")) {
            Debug.Log("colide");
        }
    }
}
