using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHandler : MonoBehaviour //wow rework this guy
{
    public GameObject story;
    public GameObject global;

    public GameObject trattoria;
    public GameObject bakery;
    public GameObject bar;
    public GameObject cafe;
    
    public InputField trattoriaInput;
    public InputField bakeryInput;
    public InputField barInput;
    //public InputField cafeInput;
    //public InputField cafeInput;
    //public InputField cafeInput;
   // public InputField cafeInput;
    
    //check the input fields of the things and if coorect then set bool to active
    
    //checking if the right input was entered then open up the next area
    
    //private string puzzle1 = "Dave."; //fuckkkk
    private string puzzle1 = "";
    private string puzzle2 = "";
    private string puzzle3 = "";
    private string puzzle4 = "";
    private string puzzle5 = "";
    private string puzzle6 = "";
    private string puzzle7 = "";
    private string end = "";
    //allows for buttons to be activated to move to piazza and docks
    //allows for buttons to be activate to move to Hills
    
    //
    
    public void Start()
    {
        global = GameObject.Find("Game Manager");
        story = GameObject.Find("Story Manager");
    }

    //checking based off asking the questions
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
