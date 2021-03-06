﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
//keeps track of the game state and other global variables that need to stay constant in the scene
//part of the game manager
{
   public static Global me;

   public bool asked = false;

   public bool moving = false;

   //STATE MACHINES
   public enum GameState //Dom State
   {
      Intro,
      Walking, 
      Viewing, 
      //Editing, 
      Selecting
   };
   public enum UIState //Sub State
   {
      Walking, //default 
      LargeMap,
      Timeline,
      Tree,
      Hill,
      Docks,
      Piazza
   };
   
   public enum LocationState 
   {
      Hills,
      Docks,
      Piazza
   };
   
   public GameState currentGS;
   public UIState currentUIS;

   public LocationState currentLocation;
   
   //PUZZLE TRACKER
   public bool puzzle1 = false;
   public bool puzzle2 = false;
   public bool puzzle3 = false;
   public bool puzzle4 = false;
   public bool puzzle5 = false;
   public bool puzzle6 = false;
   public bool end = false;

   void Awake()
   {
      me = this;
   }
   void Start() //defaulting
   {
      currentGS = GameState.Intro;
      currentUIS = UIState.Walking;
      currentLocation = LocationState.Docks;
   }
}
