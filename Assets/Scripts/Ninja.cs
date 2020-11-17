using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ninja : MonoBehaviour
{
    private bool isDead = false;
    Animator animator;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject character;
    public GameObject GameOver;
    public GameObject enemy; 


    

    void Awake()
    {
        Kill.onKill += OnDeath;
    }

    // Start is called before the first frame update
    void Start()
    {

        GameOver.SetActive(false);
        animator = GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -19f, 3f),
         Mathf.Clamp(transform.position.y, -19f, 3f), transform.position.z);

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


            if (Input.GetButtonDown("Jump"))
            {
               animator.SetInteger("Condition", 1);
            }
            else
            {
                animator.SetInteger("Condition", 0);
            }
        

         
        }

      
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
