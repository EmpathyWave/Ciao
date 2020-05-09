using System;
using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;

public class Walking : MonoBehaviour
//janky ass system to get walking working in the game
//please help me
{
    public GameObject sounds;
    public float maxSpeed;
    public float minSpeed;
    public float speed;
    public float scale;
    public Animator animator;

    public GameObject global;
    public GameObject map;
    public GameObject story;
    
    public Rigidbody2D rb;

    private bool talk = false;

    private GameObject currentChar;
    private Vector2 rightVel;
    private Vector2 leftVel;
    
    public bool facingRight;
    public bool facingLeft;

    public float timer = -1;
    private float stepTime = .38f;

    public GameObject helpScreen;
    public GameObject canvasing;
    public bool tutorial; 

    //public GameObject sounds;

    void Start()
    {
        sounds.GetComponent<SoundController>().playOcean = true;
        rb = GetComponent<Rigidbody2D>();
        global = GameObject.Find("Game Manager");
        map = GameObject.Find("Map Manager");
        story = GameObject.Find("Story Manager");
    }

    //update put controls
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && tutorial == false)
        {
            facingLeft = true;
            animator.SetBool("IsWalkingL", true);
            animator.SetBool("IsWalkingR", false);
            facingRight = false;
            //movingLeft = true;
            //movingRight = false;
            //moving = true;
        }
        
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && tutorial == false) //right
        {
            facingRight = true;
            facingLeft = false;
            animator.SetBool("IsWalkingR", true);
            animator.SetBool("IsWalkingL", false);
            //movingLeft = false;
            //moving= true;
        }
        
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            facingLeft = false;
            timer = stepTime;
            //movingRight = false;
            //moving = false;
        } 
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            facingRight = false;
            timer = stepTime;
            //movingLeft = false;
            //moving = false;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && tutorial == false)
        {
            canvasing.SetActive(true);
            helpScreen.SetActive(true);
            tutorial = true;
        }else if (Input.GetKeyUp(KeyCode.Escape) && tutorial)
        {
            helpScreen.SetActive(false);
            canvasing.SetActive(false);
            tutorial = false;
        }
        

    }
    
    void FixedUpdate()
    {
        if (global.GetComponent<Global>().currentGS == Global.GameState.Walking)
        {
            Controls();
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Controls()
    {
        //add bounds for different areas
        //change it on the camera too
        
        //moving left and right value 
        
        
        if (facingLeft && facingRight == false) //left
        {
            Debug.Log("Moving left");
            Steppy();
            //speed += scale;;
            rb.constraints = RigidbodyConstraints2D.None;
            leftVel = transform.TransformVector(-1f,0,0) * speed;
            if (rb.velocity.x < -6)
            {
                rb.velocity = new Vector2(-6f, rb.velocity.y);
            }
            else
            {
                rb.velocity += leftVel;
            }
            
            //rb.velocity += leftVel;
        } else if (facingRight && facingLeft == false) //right
        {
            Debug.Log("Moving right");
            Steppy();
            rb.constraints = RigidbodyConstraints2D.None;
            rightVel = transform.TransformVector(1f, 0, 0) * speed;
            if (rb.velocity.x > 6f)
            {
                rb.velocity = new Vector2(6f, rb.velocity.y);
            }
            else
            {
                rb.velocity += rightVel;
            }
            Debug.Log(rb.velocity);
            
            //speed += scale;
            //rb.velocity = Vector2.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.Tab))
        {
            //global.GetComponent<Global>().prevGS = Global.GameState.Viewing;
            sounds.GetComponent<SoundController>().playPT = true;
            global.GetComponent<Global>().currentUIS = Global.UIState.LargeMap;
            global.GetComponent<Global>().currentGS = Global.GameState.Viewing;
            
        }

        if (facingLeft == false && facingRight == false)
        {
            if (animator.GetBool("IsWalkingR"))
            {
                animator.SetBool("IsWalkingR", false);
            }

            if (animator.GetBool("IsWalkingL"))
            {
                animator.SetBool("IsWalkingL", false);
            }
            rb.velocity = new Vector2(0,0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll; 
        }
       
        
        if(talk && Input.GetKeyUp(KeyCode.E))
        {
            Global.me.currentGS = Global.GameState.Selecting;
            //Global.me.prevGS = Global.GameState.Selecting;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Global.me.currentUIS = Global.UIState.LargeMap;
            map.GetComponent<MapController>().current_char = currentChar.tag;
            story.GetComponent<StoryController>().SetKnot(currentChar.tag, "Default_");
            sounds.GetComponent<SoundController>().playPT = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) //is anything entering my trigger?
    {
        if (other.tag != "Untagged")
        {
            talk = true;
        }

        currentChar = other.gameObject;
    }
    
    private void OnTriggerEnter2D(Collider2D other) //is anything entering my trigger?
    {
        if (other.tag != "Untagged")
        {
            
            talk = true;
        }
        
        currentChar = other.gameObject;
    }
    
    
    private void OnTriggerExit2D(Collider2D other) //is anything entering my trigger?
    {
        if (other.tag != "Untagged")
        {
            talk = false;
        }

        currentChar = null;
    }

    private void Steppy()
    {
        if (timer < 0)
        {
            Debug.Log("Stepping");
            sounds.GetComponent<SoundController>().playStep = true;
            timer = stepTime;
        }
        timer -= Time.deltaTime;
    }
}

