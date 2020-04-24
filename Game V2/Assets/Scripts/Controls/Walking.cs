using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
//janky ass system to get walking working in the game
//please help me
{

    public float maxSpeed;
    public float minSpeed;
    public float speed;
    public float scale;

    public GameObject global;
    public GameObject map;
    public GameObject story;
    
    public Rigidbody2D rb;

    private bool talk = false;

    private GameObject currentChar;

    void Start()
    {
        //speed = minSpeed;
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
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        if (speed < minSpeed)
        {
            speed = minSpeed;
        }
    }

    void Controls()
    {
        //add bounds for different areas
        //change it on the camera too

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //left
        {
            //speed += scale;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = transform.TransformVector(-1.5f,0,0) * speed;
        } 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //right
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = transform.TransformVector(1.5f, 0, 0) * speed;
            //speed += scale;
            //rb.velocity = Vector2.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.J))
        {
            //global.GetComponent<Global>().prevGS = Global.GameState.Viewing;
            global.GetComponent<Global>().currentUIS = Global.UIState.LargeMap;
            global.GetComponent<Global>().currentGS = Global.GameState.Viewing;
            
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
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

