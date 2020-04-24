using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal.UIElements;
using UnityEngine.UI;

public class MapController : MonoBehaviour //handles all the UI elements when navigating the map and Timeline and even the story
{
    public GameObject canvas;
    
    [Header("Tabs")] 
    public GameObject mapT;
    public GameObject timeT;
    public GameObject treeT;


    [Header("Large Map")]
    public GameObject lmParent; //parent object to Large Map
    public Button[] moveButtons;

    
    [Header("Timeline")]
    public GameObject tParent; //parent object to Timeline
    public Button[] tButtons;
    
    
    [Header("Family Tree")]
    public GameObject treeParent; //parent object to tree
    public Button[] treeButtons;
   
    
    [Header("Hill")]
    public GameObject hParent; //parent object to Small Map 1
    public GameObject [] hInputs; //character
    public string [] hNames; //name storage
    public Button[] hButtons;

    [Header("Docks")]
    public GameObject dParent; //parent object to Small Map 1
    public GameObject [] dInputs; //parent of the input fields NOT THE INPUT FIELDS
    public string [] dNames; //name storage
    public Button[] dButtons;
    
    [Header("Piazza")]
    public GameObject pParent; //parent object to Small Map 1
    public GameObject [] pInputs; //parent of the input fields NOT THE INPUT FIELDS
    public string [] pNames; //name storage
    public Button[] pButtons;

    
    //inkle / story 
    [Header("Story")]
    public string current_char; //tracks which character you are currently talking to
    public bool asked = false; //check to see if the player has asked
    public string story_input1 = ""; //put into inkle system
    public string story_input2 = "";
    string story_output = ""; //what gets outputted
    public GameObject q_box;
    public GameObject d_box;
    public int input_num = 0; //checks how many inputs have been selected
    
    //managers and globals
    //public GameObject global;
    public GameObject story;
    public GameObject girl;
    
    void Start()
    {
        story = GameObject.Find("Story Manager");
        girl = GameObject.Find("Girl");
    }
    
    void Update()
    {
        Debug.Log(d_box.GetComponentInChildren<Text>().text);
        //viewing the map
        if (Global.me.currentGS == Global.GameState.Viewing) 
        {
            UIActivate();
            VControls();
            TextUpdate();
        }
        /*
        else if (Global.me.currentGS == Global.GameState.Editing) //delete it should be fine
        {
            UIActivate();
            EControls();
            TextUpdate();
        }
        */
        //questioning
        else if (Global.me.currentGS == Global.GameState.Selecting)
        {
            UIActivate();
            SControls();
            TextUpdate();
        }
        else //walking mode
        {
            UIDeactivate();
            //deactivate notes but save all text 
        }
    }
    
    //____________________________________________________________________________________________________________________________________________________UI FUNCTIONS
    //UI FUNCTIONS____________________________________________________________________________________________________________________________________________________
    void UIActivate() //activates the corresponding UI elements 
    {
        canvas.SetActive(true);
        mapT.SetActive((true));
        timeT.SetActive((true));
        treeT.SetActive((true));
        
        if (Global.me.currentUIS == Global.UIState.LargeMap) //activating large map UI
        {
            lmParent.SetActive(true);
            if (Global.me.currentGS == Global.GameState.Selecting)
            {
                for (int a = 0; a < moveButtons.Length; a++) {
                    moveButtons[a].gameObject.SetActive(false); }
            }

            tParent.SetActive(false);
            for (int b = 0; b < tButtons.Length; b++) {
                tButtons[b].gameObject.SetActive(false); }
            
            treeParent.SetActive(false);
            for (int c = 0; c < treeButtons.Length; c++) {
                treeButtons[c].gameObject.SetActive(false); }
            
            hParent.SetActive(false);
            for (int d = 0; d < hButtons.Length; d++) {
                hButtons[d].gameObject.SetActive(false); }
            
            dParent.SetActive(false);
            for (int e = 0; e < dButtons.Length; e++) {
                dButtons[e].gameObject.SetActive(false); }
            
            pParent.SetActive(false);
            for (int f = 0; f < pButtons.Length; f++) {
                pButtons[f].gameObject.SetActive(false); }
        }
        if (Global.me.currentUIS == Global.UIState.Timeline) //activating Timeline UI
        {
            tParent.SetActive(true);
            if (Global.me.currentGS == Global.GameState.Selecting)
            {
                for (int g = 0; g < tButtons.Length; g++)
                { tButtons[g].gameObject.SetActive(true); }
            }
            lmParent.SetActive(false);

            treeParent.SetActive(false);
            for (int h = 0; h < treeButtons.Length; h++) {
                treeButtons[h].gameObject.SetActive(false); }
            
            hParent.SetActive(false);
            for (int i = 0; i < hButtons.Length; i++) {
                hButtons[i].gameObject.SetActive(false); }
            
            dParent.SetActive(false);
            for (int e = 0; e < dButtons.Length; e++) {
                dButtons[e].gameObject.SetActive(false); }
            
            pParent.SetActive(false);
            for (int d = 0; d < pButtons.Length; d++) {
                pButtons[d].gameObject.SetActive(false); }
        }
        if (Global.me.currentUIS == Global.UIState.Tree) //activating tree UI
        {
            treeParent.SetActive(true);
            if (Global.me.currentGS == Global.GameState.Selecting)
            {
                for (int i = 0; i < treeButtons.Length; i++) {
                    treeButtons[i].gameObject.SetActive(true); }
            }
            
            lmParent.SetActive(false);

            tParent.SetActive(false);
            for (int i = 0; i < tButtons.Length; i++) {
                tButtons[i].gameObject.SetActive(false); }
            
            hParent.SetActive(false);
            for (int i = 0; i < hButtons.Length; i++) {
                hButtons[i].gameObject.SetActive(false); }
            
            dParent.SetActive(false);
            for (int e = 0; e < dButtons.Length; e++) {
                dButtons[e].gameObject.SetActive(false); }
            
            pParent.SetActive(false);
            for (int f = 0; f < pButtons.Length; f++) {
                pButtons[f].gameObject.SetActive(false); }
        }
        if (Global.me.currentUIS == Global.UIState.Hill) //activating hill map UI
        {
            hParent.SetActive(true);
            NameCheck();
            if (Global.me.currentGS == Global.GameState.Selecting)
            {
                for (int i = 0; i < hButtons.Length; i++) {
                    hButtons[i].gameObject.SetActive(true); }
            }
            
            lmParent.SetActive(false);
            
            tParent.SetActive(false);
            for (int i = 0; i < tButtons.Length; i++) {
                tButtons[i].gameObject.SetActive(false); }
            
            treeParent.SetActive(false);
            for (int i = 0; i < treeButtons.Length; i++) {
                treeButtons[i].gameObject.SetActive(false); }
            
            dParent.SetActive(false);
            for (int e = 0; e < dButtons.Length; e++) {
                dButtons[e].gameObject.SetActive(false); }
            
            pParent.SetActive(false);
            for (int f = 0; f < pButtons.Length; f++) {
                pButtons[f].gameObject.SetActive(false); }
        }
        if (Global.me.currentUIS == Global.UIState.Docks) //activating dock map UI
        {
            dParent.SetActive(true);
            NameCheck();
            if (Global.me.currentGS == Global.GameState.Selecting)
            {
                for (int i = 0; i < dButtons.Length; i++) {
                    dButtons[i].gameObject.SetActive(true); }
            }
            
            lmParent.SetActive(false);
            
            tParent.SetActive(false);
            for (int i = 0; i < tButtons.Length; i++) {
                tButtons[i].gameObject.SetActive(false); }

            treeParent.SetActive(false);
            for (int i = 0; i < treeButtons.Length; i++) {
                treeButtons[i].gameObject.SetActive(false); }
            
            hParent.SetActive(false);
            for (int i = 0; i < hButtons.Length; i++) {
                hButtons[i].gameObject.SetActive(false); }

            pParent.SetActive(false);
            for (int f = 0; f < pButtons.Length; f++) {
                pButtons[f].gameObject.SetActive(false); }
        }
        if (Global.me.currentUIS == Global.UIState.Piazza) //activating piazza map UI
        {
            pParent.SetActive(true);
            NameCheck();
            if (Global.me.currentGS == Global.GameState.Selecting)
            {
                for (int i = 0; i < pButtons.Length; i++) {
                    pButtons[i].gameObject.SetActive(true); }
            }
            
            lmParent.SetActive(false);
            
            tParent.SetActive(false);
            for (int i = 0; i < tButtons.Length; i++) {
                tButtons[i].gameObject.SetActive(false); }

            treeParent.SetActive(false);
            for (int i = 0; i < treeButtons.Length; i++) {
                treeButtons[i].gameObject.SetActive(false); }
            
            hParent.SetActive(false);
            for (int i = 0; i < hButtons.Length; i++) {
                hButtons[i].gameObject.SetActive(false); }

            dParent.SetActive(false);
            for (int e = 0; e < dButtons.Length; e++) {
                dButtons[e].gameObject.SetActive(false); }
        }
    }

    void UIDeactivate() //defaults to walking on everything
    {
        canvas.SetActive(false);
        mapT.SetActive(false);
        timeT.SetActive(false);
        treeT.SetActive(false);
        
        lmParent.SetActive(false);
        tParent.SetActive(false);
        treeParent.SetActive(false);
        hParent.SetActive(false);
        dParent.SetActive(false);
        pParent.SetActive(false);

        for (int i = 0; i < tButtons.Length; i++) {
            tButtons[i].gameObject.SetActive(false); }
        for (int i = 0; i < treeButtons.Length; i++) {
            treeButtons[i].gameObject.SetActive(false); }
        for (int i = 0; i < hButtons.Length; i++) {
            hButtons[i].gameObject.SetActive(false); }
        for (int i = 0; i < dButtons.Length; i++) {
            dButtons[i].gameObject.SetActive(false); }
        for (int i = 0; i < pButtons.Length; i++) {
            pButtons[i].gameObject.SetActive(false); }
        
        //add docks and piazza
        
        d_box.SetActive(false);
        q_box.SetActive(false);
    }
    
    //_____________________________________________________________________________________________________________________________________________________CONTROLS
    //CONTROLS ____________________________________________________________________________________________________________________________________________________
    void VControls() //viewing controls
    {
        if (Input.GetKey(KeyCode.Escape)) // changes into walking 
        {
            Debug.Log("Fuck");
            Global.me.currentUIS = Global.UIState.Walking; //walkin UI
            Global.me.currentGS = Global.GameState.Walking; //walkin time
        }
    }

    //delete 
    /*
    void EControls() //switching from editing to whatever the fuck you were doing before
    {
        //Tab();
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Global.me.currentGS = Global.me.prevGS; //back to map
        }
        
    }
    */
    void SControls() //selecting controls
    {
        
        q_box.SetActive(true);
        d_box.SetActive(true);
        NameCheck();
        
        //calls the Story Controller function
        if (Global.me.asked)
        {
            //filters out the spaces for input into Inkle
            story.GetComponent<StoryController>().SetKnot(current_char, story.GetComponent<StoryController>().Sort(story_input1,story_input2));
            //Debug.Log(story.GetComponent<StoryController>().currentKnot);
            q_box.GetComponentInChildren<Text>().text = "";
            
            
                for (int i = 0; i < tButtons.Length; i++) //resets buttons
                {
                    tButtons[i].gameObject.SetActive(true);
                    tButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
            
                for (int i = 0; i < treeButtons.Length; i++) //resets buttons
                {
                    treeButtons[i].gameObject.SetActive(true);
                    treeButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
            
                for (int i = 0; i < hButtons.Length; i++) //resets buttons
                {
                    hButtons[i].gameObject.SetActive(true);
                    hButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
                for (int i = 0; i < dButtons.Length; i++) //resets buttons
                {
                    dButtons[i].gameObject.SetActive(true);
                    dButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
                for (int i = 0; i < pButtons.Length; i++) //resets buttons
                {
                    pButtons[i].gameObject.SetActive(true);
                    pButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
            

            //d_box.GetComponentInChildren<Text>().text = story_output;
            input_num = 0;
            Global.me.asked = false;
        }
        
        //story.GetComponent<StoryController>().SetKnot(current_char, "Default_");
        story_output = story.GetComponent<StoryController>().output;
        d_box.GetComponentInChildren<Text>().text = story_output;

        if (Input.GetKey(KeyCode.Escape)) //exists out of convo
        {
            d_box.GetComponentInChildren<Text>().text = "";
            q_box.GetComponentInChildren<Text>().text = "";
            story_output = "";
            
                for (int i = 0; i < tButtons.Length; i++) //resets buttons
                {
                    tButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                    tButtons[i].gameObject.SetActive(false);
                }
            
            
                for (int i = 0; i < treeButtons.Length; i++) //resets buttons
                {
                    treeButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                    treeButtons[i].gameObject.SetActive(false);
                }
            
            
                for (int i = 0; i < hButtons.Length; i++) //resets buttons
                {
                    hButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                    hButtons[i].gameObject.SetActive(false);
                }
                for (int i = 0; i < dButtons.Length; i++) //resets buttons
                {
                    dButtons[i].gameObject.SetActive(false);
                    dButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
                for (int i = 0; i < pButtons.Length; i++) //resets buttons
                {
                    pButtons[i].gameObject.SetActive(false);
                    pButtons[i].gameObject.GetComponent<Button>().interactable = true; 
                }
            
            input_num = 0;
            //story.GetComponent<StoryController>().SetKnot(current_char, "Default_");
            Global.me.currentUIS = Global.UIState.Walking; //back to walking UI
            Global.me.currentGS = Global.GameState.Walking; //back to walking
        }    
    }

    //_____________________________________________________________________________________________________________________________________________WORKER FUNCTIONS
    //WORKER FUNCTIONS ____________________________________________________________________________________________________________________________________________
    
    public void TextUpdate()
    {
        if (Global.me.currentUIS == Global.UIState.Hill) //Hill
        {
            for (int i = 0; i < hInputs.Length; i++)
            {
                hNames[i] = hInputs[i].transform.GetChild(2).GetComponent<InputField>().text;
                hInputs[i].transform.GetChild(2).GetComponent<InputField>().text = hNames[i];
                hInputs[i].transform.GetChild(3).GetComponent<InputField>().text= hNames[i];
            }
        }
        if (Global.me.currentUIS == Global.UIState.Docks) //Hill
        {
            for (int i = 0; i < dInputs.Length; i++)
            {
                dNames[i] = dInputs[i].transform.GetChild(2).GetComponent<InputField>().text;
                dInputs[i].transform.GetChild(2).GetComponent<InputField>().text = dNames[i];
                dInputs[i].transform.GetChild(3).GetComponent<InputField>().text= dNames[i];
            }
        }
        if (Global.me.currentUIS == Global.UIState.Piazza) //Hill
        {
            for (int i = 0; i < pInputs.Length; i++)
            {
                pNames[i] = pInputs[i].transform.GetChild(2).GetComponent<InputField>().text;
                pInputs[i].transform.GetChild(2).GetComponent<InputField>().text = pNames[i];
                pInputs[i].transform.GetChild(3).GetComponent<InputField>().text= pNames[i];
            }
        }
    }
    
    
    
    void NameCheck() //checking if the names and inputs are correct and displaying the correct info if they are //called whcn acvtivating the UI
    {
        if (Global.me.currentUIS == Global.UIState.Hill) //Hill
        {
            for (int i = 0; i < hInputs.Length; i++)
            {
                if (hNames[i] == hInputs[i].name) //just seeing if the names are right
                {
                    //0 = incorrect sprite
                    //1 = correct sprite
                    //2 = incorrect input
                    //3 = correct input
                    //4 = button
                    
                    //setting the target graphic
                    hInputs[i].transform.GetChild(0).gameObject.SetActive(false); //incorrect
                    hInputs[i].transform.GetChild(1).gameObject.SetActive(true); //correct
                    
                    hInputs[i].transform.GetChild(2).gameObject.SetActive(false); //false input
                    hInputs[i].transform.GetChild(3).gameObject.SetActive(true); //correct input
                    //change back to set active
                    //fix all the other parts of the function
                } else {
                    hInputs[i].transform.GetChild(0).gameObject.SetActive(true); //incorrect
                    hInputs[i].transform.GetChild(1).gameObject.SetActive(false); //correct
                    
                    hInputs[i].transform.GetChild(2).gameObject.SetActive(false); //false input
                    hInputs[i].transform.GetChild(3).gameObject.SetActive(true); //correct input
                    //change back to set active
                }

                if (Global.me.currentGS == Global.GameState.Selecting && hNames[i] == hInputs[i].name) //activating buttons
                {
                    //Debug.Log(hInputs[i].transform.GetChild(4).gameObject.name+ "true");
                    hInputs[i].transform.GetChild(4).gameObject.SetActive(true);
                    
                    //hInputs[i].transform.GetChild(3).gameObject.SetActive(false); //set to not active so they can't edit it if it's correct''
                    hInputs[i].transform.GetChild(2).GetComponent<InputField>().interactable = false;
                    hInputs[i].transform.GetChild(3).GetComponent<InputField>().interactable = false;
                    //change back to set active
                    
                } else {
                    //Debug.Log(hInputs[i].transform.GetChild(4).gameObject.name + "false");
                    //hInputs[i].transform.GetChild(4).gameObject.SetActive(false);
                    hInputs[i].transform.GetChild(2).GetComponent<InputField>().interactable = true;
                    hInputs[i].transform.GetChild(3).GetComponent<InputField>().interactable = true;
                }
                
            }
        }
        if (Global.me.currentUIS == Global.UIState.Docks) //Docks
        {
            for (int i = 0; i < dInputs.Length; i++)
            {
                if (dNames[i] == dInputs[i].name) //just seeing if the names are right
                {
                    //0 = incorrect sprite
                    //1 = correct sprite
                    //2 = incorrect input
                    //3 = correct input
                    //4 = button
                    
                    //setting the target graphic
                    dInputs[i].transform.GetChild(0).gameObject.SetActive(false); //incorrect
                    dInputs[i].transform.GetChild(1).gameObject.SetActive(true); //correct
                    dInputs[i].transform.GetChild(2).gameObject.SetActive(false); //false
                    dInputs[i].transform.GetChild(3).gameObject.SetActive(true); //correct
                } else {
                    dInputs[i].transform.GetChild(0).gameObject.SetActive(true); //incorrect
                    dInputs[i].transform.GetChild(1).gameObject.SetActive(false); //correct
                    dInputs[i].transform.GetChild(2).gameObject.SetActive(true); //false
                    dInputs[i].transform.GetChild(3).gameObject.SetActive(false); //correct
                    //set interactable or not 
                }

                if (Global.me.currentGS == Global.GameState.Selecting && dNames[i] == dInputs[i].name) //activating buttons
                {
                    //Debug.Log(dInputs[i].transform.GetChild(4).gameObject.name+ "true");
                    dInputs[i].transform.GetChild(4).gameObject.SetActive(true);
                    
                    //dInputs[i].transform.GetChild(3).gameObject.SetActive(false); //correct
                    dInputs[i].transform.GetChild(3).GetComponent<InputField>().interactable = false;
                    dInputs[i].transform.GetChild(2).GetComponent<InputField>().interactable = false;
                    //Global.me.currentGS = Global.GameState.Selecting;
                } else {
                    //Debug.Log(dInputs[i].transform.GetChild(4).gameObject.name + "false");
                    //dInputs[i].transform.GetChild(4).gameObject.SetActive(false);
                    dInputs[i].transform.GetChild(3).GetComponent<InputField>().interactable = true;
                    dInputs[i].transform.GetChild(2).GetComponent<InputField>().interactable = true;
                }
                
            }
        }
        
        if (Global.me.currentUIS == Global.UIState.Piazza) //Piazza
        {
            for (int i = 0; i < pInputs.Length; i++)
            {
                if (pNames[i] == pInputs[i].name) //just seeing if the names are right
                {
                    //0 = incorrect sprite
                    //1 = correct sprite
                    //2 = incorrect input
                    //3 = correct input
                    //4 = button
                    
                    //setting the target graphic
                    pInputs[i].transform.GetChild(0).gameObject.SetActive(false); //incorrect
                    pInputs[i].transform.GetChild(1).gameObject.SetActive(true); //correct
                    pInputs[i].transform.GetChild(2).gameObject.SetActive(false); //false
                    pInputs[i].transform.GetChild(3).gameObject.SetActive(true); //correct
                } else {
                    pInputs[i].transform.GetChild(0).gameObject.SetActive(true); //incorrect
                    pInputs[i].transform.GetChild(1).gameObject.SetActive(false); //correct
                    pInputs[i].transform.GetChild(2).gameObject.SetActive(true); //false
                    pInputs[i].transform.GetChild(3).gameObject.SetActive(false); //correct
                    //set interactable or not 
                }

                if (Global.me.currentGS == Global.GameState.Selecting && pNames[i] == pInputs[i].name) //activating buttons
                {
                    //Debug.Log(pInputs[i].transform.GetChild(4).gameObject.name+ "true");
                    pInputs[i].transform.GetChild(4).gameObject.SetActive(true); //sets the button to active
                    
                    //pInputs[i].transform.GetChild(3).gameObject.SetActive(false);
                    pInputs[i].transform.GetChild(3).GetComponent<InputField>().interactable = false;
                    pInputs[i].transform.GetChild(2).GetComponent<InputField>().interactable = false;//correct
                    //Global.me.currentGS = Global.GameState.Selecting;
                } else {
                    //Debug.Log(pInputs[i].transform.GetChild(4).gameObject.name + "false");
                    //pInputs[i].transform.GetChild(4).gameObject.SetActive(false);
                    pInputs[i].transform.GetChild(3).GetComponent<InputField>().interactable = true;
                    pInputs[i].transform.GetChild(2).GetComponent<InputField>().interactable = true;
                }
                
            }
        }
        
    }
}


