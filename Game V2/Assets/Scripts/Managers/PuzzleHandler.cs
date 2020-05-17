using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHandler : MonoBehaviour //wow rework this guy
{
    public GameObject story;
    //public GameObject global;
    
    public InputField EmiliaCordella;
    public InputField Lucianos;
    public InputField Piccola;

    public GameObject PLLD; //Piccola Lit, Lucianos dark
    public GameObject PLLL; //Piccola Lit, Lucianos lit
    public GameObject PDLL; //Piccola Dark, Lucianos lit
    public GameObject PDLD; //Piccola Dark, Lucianos dark

    public Button piazzamov;
    public Button hillsmov;

    public GameObject garfield;
    
    private string solution1 = "CafeOwner.PiccolaPanetteria_";
   //solution 2 is going to the new location 
    private string solution3 = "Emilia Cardello";
    private string solution4 = "Bartender.EmiliaCardello_";
    private string solution5 = "EmiliaCardello.EmiliaCardello0UncleLucca_";
    private string endSolution = "UncleLucca.Default_";
    
   //going to the new location is the 6th solution

   //check the input fields of the things and if coorect then set bool to active
    
    //checking if the right input was entered then open up the next area
    
    //private string puzzle1 = "Dave."; //fuckkkk
    //allows for buttons to be activated to move to piazza and docks
    //allows for buttons to be activate to move to Hills
    
    //
    
    public void Start()
    {
        //global = GameObject.Find("Game Manager");
        story = GameObject.Find("Story Manager");
    }

    //checking based off asking the questions
    void Update() //when the button is pressed it checks if it satisfies
    {

        if (EmiliaCordella.text == "Garfield")
        {
            garfield.SetActive(true);
        }
        if (story.GetComponent<StoryController>().currentKnot == solution1)
        {
            Global.me.puzzle1 = true;
            piazzamov.interactable = true;
        }

        if (Global.me.puzzle1 == false)
        {
            piazzamov.interactable = false;
        }

        if (Global.me.currentLocation == Global.LocationState.Piazza)
        {
            Global.me.puzzle2 = true;
        }
        
        if (EmiliaCordella.text == solution3)
        {
            Global.me.puzzle3 = true;
        }
        
        if (story.GetComponent<StoryController>().currentKnot == solution4)
        {
            Global.me.puzzle4 = true;
        }
        
        if (story.GetComponent<StoryController>().currentKnot == solution5)
        {
            Global.me.puzzle5 = true;
            hillsmov.interactable = true;
        }
        if (Global.me.puzzle5 == false)
        {
            hillsmov.interactable = false;
        }
        
        if (Global.me.currentLocation == Global.LocationState.Hills)
        {
            Global.me.puzzle6 = true;
        }
    
        if (story.GetComponent<StoryController>().currentKnot == endSolution)
        {
            Global.me.end = true;
        }


        if (Piccola.text == "Piccola Panetteria")
        {
            if (Lucianos.text == "Luciano's")
            {
                PLLD.SetActive(false); //Piccola Lit, Lucianos dark  
                PLLL.SetActive(true); //Piccola Lit, Lucianos lit 
                PDLL.SetActive(false); //Piccola Dark, Lucianos lit 
                PDLD.SetActive(false); //Piccola Dark, Lucianos dark 
            }
            else
            {
                PLLD.SetActive(true); //Piccola Lit, Lucianos dark  
                PLLL.SetActive(false); //Piccola Lit, Lucianos lit 
                PDLL.SetActive(false); //Piccola Dark, Lucianos lit 
                PDLD.SetActive(false); //Piccola Dark, Lucianos dark 
            }
        }
        else
        {
            if (Lucianos.text == "Luciano's")
            {
                PLLD.SetActive(false); //Piccola Lit, Lucianos dark  
                PLLL.SetActive(false); //Piccola Lit, Lucianos lit 
                PDLL.SetActive(true); //Piccola Dark, Lucianos lit 
                PDLD.SetActive(false); //Piccola Dark, Lucianos dark 
            }
            else
            {
                PLLD.SetActive(false); //Piccola Lit, Lucianos dark  
                PLLL.SetActive(false); //Piccola Lit, Lucianos lit 
                PDLL.SetActive(false); //Piccola Dark, Lucianos lit 
                PDLD.SetActive(true); //Piccola Dark, Lucianos dark 
            }
        }
        
        
        //checking the buttons
        
        // if the name is correct then
        //activate the shader script on the building!
    }
}
