using System;
using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour ///delete and rename input field and button handler 
{
    public GameObject sounds;
    
    bool asked = false;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        //global = GameObject.Find("Game Manager");
        map = GameObject.Find("Map Manager");
    }

    public void ButtonHandler(Button button) //sends up the button name to the story input
    {
        sounds.GetComponent<SoundController>().playAddQ = true;
        Debug.Log("clicked");
        if (map.GetComponent<MapController>().input_num == 0)
        {
            map.GetComponent<MapController>().q_box.GetComponentInChildren<Text>().text += button.name;
            map.GetComponent<MapController>().story_input1 = button.name.Replace(" ", String.Empty);
            map.GetComponent<MapController>().input_num = 1;
            button.interactable = false;
        } else if (map.GetComponent<MapController>().input_num == 1) {
            map.GetComponent<MapController>().q_box.GetComponentInChildren<Text>().text += " & ";
            map.GetComponent<MapController>().q_box.GetComponentInChildren<Text>().text += button.name;
            map.GetComponent<MapController>().story_input2 = button.name.Replace(" ", String.Empty);
            button.interactable = false;
            map.GetComponent<MapController>().input_num = 2;
        }
        //changing the ui to onl;y be selected state when the button is clicked
        if (map.GetComponent<MapController>().input_num == 2)
        {
            for (int i = 0; i < map.GetComponent<MapController>().tButtons.Length; i++) //resets buttons
            {
                //map.GetComponent<MapController>().tButtons[i].gameObject.GetComponent<Button>().interactable = false; 
                map.GetComponent<MapController>().tButtons[i].gameObject.SetActive(false);
            }
            
            for (int i = 0; i < map.GetComponent<MapController>().treeButtons.Length; i++) //resets buttons
            {
                //map.GetComponent<MapController>().treeButtons[i].gameObject.GetComponent<Button>().interactable = false; 
                map.GetComponent<MapController>().treeButtons[i].gameObject.SetActive(false);
            }
            
            for (int i = 0; i < map.GetComponent<MapController>().hButtons.Length; i++) //resets buttons
            {
                //map.GetComponent<MapController>().hButtons[i].gameObject.GetComponent<Button>().interactable = false; 
                map.GetComponent<MapController>().hButtons[i].gameObject.SetActive(false);
            }
            
            for (int i = 0; i < map.GetComponent<MapController>().dButtons.Length; i++) //resets buttons
            {
                map.GetComponent<MapController>().dButtons[i].gameObject.SetActive(false);
            }
            
            for (int i = 0; i < map.GetComponent<MapController>().pButtons.Length; i++) //resets buttons
            {
                map.GetComponent<MapController>().pButtons[i].gameObject.SetActive(false);
            }
        }
    }
    
    /*
    public void Save() // saving the text once the input field is called
    {
        if (Global.me.currentUIS == Global.UIState.Hill) //Hill
        {
            for (int i = 0; i < map.GetComponent<MapController>().hInputs.Length; i++)
            {
                map.GetComponent<MapController>().hNames[i] = map.GetComponent<MapController>().hInputs[i].transform.GetChild(0).GetComponentInChildren<InputField>().text;
            }
        }
        if (Global.me.currentUIS == Global.UIState.Docks) //docks
        {
            for (int i = 0; i < map.GetComponent<MapController>().dInputs.Length; i++)
            {
                map.GetComponent<MapController>().dNames[i] = map.GetComponent<MapController>().dInputs[i].transform.GetChild(0).GetComponentInChildren<InputField>().text;
            }
        }
        //add the rest of it
    }
    
    
    public void End_Editing() //ending editing - switching to previous mode fixes problem of game states
    {
        Global.me.currentGS = Global.me.prevGS; 
        Global.me.prevGS = Global.me.currentGS;
    }
    
    public void Start_Editing() 
    {
        Global.me.currentGS = Global.GameState.Editing;
        
        //logic to assign the correct previous state to the variable, making sure editing doesn't become one of them
        if (Global.me.prevGS == Global.GameState.Viewing)
        {
            Global.me.prevGS = Global.GameState.Viewing;
        }
        else if (Global.me.prevGS == Global.GameState.Selecting)
        {
            Global.me.prevGS = Global.GameState.Selecting;
        }
    }
    */
    
    public void Ask() 
    {
        Global.me.asked = true;
        sounds.GetComponent<SoundController>().playAskQ = true;
        //sounds.GetComponent<SoundController>().playTS = true;
    }

    public void Piazza()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentUIS = Global.UIState.Piazza;
    }
    public void PiazzaMov()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentLocation = Global.LocationState.Piazza;
        Global.me.moving = true;
    }
    
    public void Docks()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentUIS = Global.UIState.Docks;
    }

    public void DocksMov()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentLocation = Global.LocationState.Docks;
        Global.me.moving = true;
    }
    
    public void Hill()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentUIS = Global.UIState.Hill;
    }
    public void HillsMov()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentLocation = Global.LocationState.Hills;
        Global.me.moving = true;
    }
    
    public void tree()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentUIS = Global.UIState.Tree;
    }
    
    public void Timeline()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentUIS = Global.UIState.Timeline;
    }
    
    public void LargeMap()
    {
        sounds.GetComponent<SoundController>().playPT = true;
        Global.me.currentUIS = Global.UIState.LargeMap;
    }
}
