using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHandler : MonoBehaviour
{
    public GameObject story;
    public GameObject global;

    public GameObject trattoria;
    public GameObject bakery;
    public GameObject bar;
    public GameObject cafe;
    
    public InputField trattoriaIn;
    public InputField bakeryIn;
    public InputField barIn;
    public InputField cafeIn;
    
    //solutions
    //private string puzzle1 = "Dave."; //fuckkkk
    private string puzzle1 = "";
    //allows for buttons to be activated to move to piazza and docks
    //allows for buttons to be activate to move to Hills
    
    //

    public void Start()
    {
        global = GameObject.Find("Game Manager");
        story = GameObject.Find("Story Manager");
    }

    public void Check() //when the button is pressed it checks if it satisfies
    {
        if (story.GetComponent<StoryController>().currentKnot == puzzle1)
        {
            global.GetComponent<Global>().puzzle1 = true;
        }
        
        // if the name is correct then
        //activate the shader script on the building!
    }
}
