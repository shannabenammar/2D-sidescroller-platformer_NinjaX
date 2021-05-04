using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    int moveSpeed = 2;
    int attackDamage;
    int hitpoints;
    public float lookRadius = 4f;
    public float attackRadius = 1f;
    Transform target;
    SpriteRenderer enemy;
    Rigidbody2D enemyrb;
    public Animator animator;

    void Start() {
        target = PlayerManager.instance.player.transform;
        enemy = GetComponent<SpriteRenderer>();
        enemyrb = GetComponent<Rigidbody2D>();

        hitpoints = 100;
    }

    void Update(){
        // MVP: Add attacking code
        // MVP: Add attacking animation

        //is player in enemy view range
        if(Mathf.Abs(target.position.x - transform.position.x) < lookRadius){ 
            // check if player is infront of enemy 
            if(target.position.x < transform.position.x) {
                //check for attack radius
                if(Mathf.Abs(target.position.x - transform.position.x) < attackRadius){
                    enemyrb.velocity = Vector3.zero;
                    //do attack animation
                    animator.SetBool("canAttack?", true);
                }
                
                // else move to player
                else{
                    animator.SetBool("canAttack?", false);
                    this.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
                    enemy.flipX = false;

                    animator.SetBool("isMoving?", true);
                }


            }        
            //check if player is behind enemy
            else if(target.position.x > transform.position.x) {
                //check for attack radius
                if(Mathf.Abs(target.position.x - transform.position.x) < attackRadius){
                    enemyrb.velocity = Vector3.zero;
                    //do attack animation
                    animator.SetBool("canAttack?", true);
                }
                //else move to player
                else { 
                    animator.SetBool("canAttack?", false);                 
                    this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    // flips the enemy to face the player
                    enemy.flipX = true;                    
                    
                    animator.SetBool("isMoving?", true);

                }
            }
        } 
        // player outside of viewrange
        else {
            // MVP: Add idle animation here
            animator.SetBool("canAttack?", false);
            animator.SetBool("isMoving?", false);
            // Stretch: look into adding functionality for the enemy to be passively moving
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name.Equals("weapon")) {
            hitpoints -= 50;
        }
    }
}
