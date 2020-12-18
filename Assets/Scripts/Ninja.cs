using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ninja : MonoBehaviour
{
    private bool isDead = false;
    public Animator animator;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject character;
    public GameObject GameOver;
    public GameObject enemy;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D player;

    float mx;
    public static int hitpoints;
    private SpriteRenderer spriteRenderer;

    public Transform feet;

    public LayerMask groundLayers;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        Kill.onKill += OnDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        hitpoints = 100;
        GameOver.SetActive(false);
        animator = GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {

        mx = Input.GetAxisRaw("Horizontal");

       // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -19f, 3f),
        // Mathf.Clamp(transform.position.y, -19f, 3f), transform.position.z);

        if (!isDead)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                animator.SetBool("attack", true);
            }
            else
            {
                animator.SetBool("attack", false);
            }


            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                Jump();
                
            }
            else
            {
                animator.SetInteger("Condition", 0);
            }
    
         if (mx != 0 && isGrounded())//(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
         {
             //  if (Input.GetKey(KeyCode.LeftArrow)) spriteRenderer.flipX;

                    animator.SetBool("isWalking", true);
         }
         else{
             animator.SetBool("isWalking", false);
         }
    
    
      }

      
    }

    void Jump()
    {
        animator.SetInteger("Condition", 1);
        Vector2 movement = new Vector2(player.velocity.x, jumpForce);

        player.velocity = movement;
    }

    bool isGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        Debug.Log(groundCheck);
        if(groundCheck) {
            return true;
        }

        return false;
    
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * moveSpeed, player.velocity.y);
        player.velocity = movement;
    }
    void OnDeath()
    {
        if (!animator.GetBool("attack"))
        {

            animator.SetBool("isDead", true);
            MusicController.instance.ninjaDiedSound();
            StartCoroutine("Wait");
        }
        else
        {
            animator.SetBool("BatDied", true);

        }
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Tony"))
        {
            hitpoints -= 30;
        }
        if (collider.gameObject.name.Equals("back wall"))
        {
            Debug.Log("colide");
        }
    }
    void OnDestroy()
    {
        Kill.onKill -= OnDeath;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        GameOver.SetActive(true);
    }
}
