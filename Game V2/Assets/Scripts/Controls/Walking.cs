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
    
    //public GameObject sounds;

    void Start()
    {
        sounds.GetComponent<SoundController>().playOcean = true;
        rb = GetComponent<Rigidbody2D>();
        global = GameObject.Find("Game Manager");
        map = GameObject.Find("Map Manager");
        story = GameObject.Find("Story Manager");
    }


    void FixedUpdate()
    {
        if (global.GetComponent<Global>().currentGS == Global.GameState.Walking)
        {
            Controls();
            Check();
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Check()
    {
    }

    void Controls()
    {
        //add bounds for different areas
        //change it on the camera too

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //left
        {
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
            animator.SetBool("IsWalkingL", true);

        } 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //right
        {
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
            animator.SetBool("IsWalkingR", true);
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

        //i think this is the problem
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(0,0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetBool("IsWalkingR", false);

        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0,0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetBool("IsWalkingL", false);
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
}

