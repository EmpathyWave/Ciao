using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //public bool test;
    
    //add in puzzle theme
    //footsteps need the tutorial
    //add in hill area when it's in the game
    public StudioEventEmitter emitter;
    //public string Event;

    [FMODUnity.EventRef]
    [Header("Music")]
    public string Theme = " ";
    public bool playT;
    public bool stopT;
    FMOD.Studio.EventInstance theme;
    
    [FMODUnity.EventRef]
    public string Puzzle = " ";
    public bool playP;
    public bool stopP;
    FMOD.Studio.EventInstance puzzle;
    
    [FMODUnity.EventRef]
    [Header("UI")]
    public string PageTurn = "";
    public bool playPT;
    //public bool stopPT;
    FMOD.Studio.EventInstance pageTurn;
    [FMODUnity.EventRef]
    public string AddQ = " ";
    public bool playAddQ;
    //public bool stopAddQ;
    FMOD.Studio.EventInstance addQ;
    [FMODUnity.EventRef]
    public string AskQ = " ";
    public bool playAskQ;
    //public bool stopAskQ;
    FMOD.Studio.EventInstance askQ;
    [FMODUnity.EventRef]
    public string TextScroll = " ";
    public bool playTS;
    public bool stopTS;
    FMOD.Studio.EventInstance textScroll;
    //public FMOD.Studio.EventInstance end;
    
    
    [Header("Docks")]
    [FMODUnity.EventRef]
    public string Ocean = " ";
    public bool playOcean;
    public bool stopOcean;
    FMOD.Studio.EventInstance ocean;
    [FMODUnity.EventRef]
    public string Seagull = " "; //randomize
    public bool playSeagull;
    //public bool stopSeagull;
    FMOD.Studio.EventInstance seagull;
    
    [FMODUnity.EventRef]
    [Header("Piazza")]
    public string Foutain = " ";
    public bool playFoutain;
    public bool stopFoutain;
    FMOD.Studio.EventInstance foutain;
    [FMODUnity.EventRef]
    public string Chatter = " ";
    public bool playChatter;
    public bool stopChatter;
    FMOD.Studio.EventInstance chatter;
    [FMODUnity.EventRef]
    public string Sweet = " "; //randomize
    public bool playSweet;
    FMOD.Studio.EventInstance sweet; 
    
    
    [FMODUnity.EventRef]
    [Header("Hills")]
    public string Enviro = " ";
    public bool playEnviro;
    public bool stopEnviro;
    FMOD.Studio.EventInstance enviro;
    [FMODUnity.EventRef]
    public string Birds = " "; //randomize
    public bool playBirds;
    FMOD.Studio.EventInstance birds;
    [FMODUnity.EventRef]
    public string Sweeties = " "; //randomize
    public bool playSweeties;
    FMOD.Studio.EventInstance sweeties;
    
    [FMODUnity.EventRef]
    [Header("Footsteps")]
    public string Step = " ";
    public bool playStep;
    FMOD.Studio.EventInstance step;
    
    //private FMOD.Studio.PLAYBACK_STATE playbackState;
    
    // Start is called before the first frame update
    void Start()
    {
        theme = FMODUnity.RuntimeManager.CreateInstance(Theme);
        pageTurn = FMODUnity.RuntimeManager.CreateInstance(PageTurn);
        addQ = FMODUnity.RuntimeManager.CreateInstance(AddQ);
        askQ = FMODUnity.RuntimeManager.CreateInstance(AskQ);
        textScroll = FMODUnity.RuntimeManager.CreateInstance(TextScroll);
        //textScroll.getParameterByName("Textscroll End", out end);
        //textEnd = FMODUnity.RuntimeManager.CreateInstance(TextEnd);
        ocean = FMODUnity.RuntimeManager.CreateInstance(Ocean);
        //wind = FMODUnity.RuntimeManager.CreateInstance(Wind);
        seagull = FMODUnity.RuntimeManager.CreateInstance(Seagull);
        foutain = FMODUnity.RuntimeManager.CreateInstance(Foutain);
        chatter = FMODUnity.RuntimeManager.CreateInstance(Chatter);
        sweet = FMODUnity.RuntimeManager.CreateInstance(Sweet);
        enviro = FMODUnity.RuntimeManager.CreateInstance(Enviro);
        birds = FMODUnity.RuntimeManager.CreateInstance(Birds);
        sweeties = FMODUnity.RuntimeManager.CreateInstance(Sweeties);
        step = FMODUnity.RuntimeManager.CreateInstance(Step);
        //clock = FMODUnity.RuntimeManager.CreateInstance(Clock);
        //birds = FMODUnity.RuntimeManager.CreateInstance(Birds);
    }

    // Update is called once per frame
    void Update()
    {
        //music---------------------------------------------------
        if (playT)
        {
            theme.start();
            playT = false;
        }

        //UI-----------------------------------------------------------
        if (playPT)
        {
            pageTurn.start();
            playPT = false;
        }

        if (playAddQ)
        {
            addQ.start();
            playAddQ = false;
        }
        
        if (playAskQ)
        {
            askQ.start();
            playAskQ = false;
        }
        
        if (playTS)
        {
            textScroll.setParameterByName("Textscroll End", 0f);
            textScroll.start();
            playTS = false;
        }
        if (stopTS)
        {
            textScroll.setParameterByName("Textscroll End", 1f); //SetParameter("Textscroll End",1);;
            stopTS = false;
        }
        
        
        //Docks--------------------------------------------------------------
        if (playOcean)
        {
            ocean.start();
            playOcean = false;
        }
        if (stopOcean)
        {
            ocean.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            stopOcean = false;
        }

        if (playSeagull)
        {
            seagull.start();
            playSeagull = false;
        }
        
        //Piazza----------------------------------------------------------
        if(playFoutain)
        {
            foutain.start();
            playFoutain = false;
        }
        if (stopFoutain)
        {
            foutain.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            stopFoutain = false;
        }

        if(playChatter)
        {
            chatter.start();
            playChatter = false;
        }
        if (stopChatter)
        {
            chatter.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            stopChatter = false;
        }

        if (playSweet)
        {
            sweet.start();
            playSweet = false;
        }
        
        //hills -------------------------------------------------------
        if (playEnviro)
        {
            enviro.start();
            playEnviro = false;
        }
        if (stopEnviro)
        {
            enviro.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            stopEnviro = false;
        }

        if (playBirds)
        {
            birds.start();
            playBirds = false;
        }
        
        if (playSweeties)
        {
            sweeties.start();
            playSweeties = false;
        }
        
        //-----------------------------------------------------------
        if (playStep)
        {
            step.start();
            playStep = false;
        }

        if (Global.me.puzzle1)
        {
            emitter.SetParameter("Layer 2",1);
        }
        if (Global.me.puzzle2)
        {
            emitter.SetParameter("Layer 3",1);
        }
        if (Global.me.puzzle3)
        {
            emitter.SetParameter("Layer 4",1);
        }
        if (Global.me.puzzle4)
        {
            emitter.SetParameter("Layer 5",1);
        }
        if (Global.me.puzzle5)
        {
            emitter.SetParameter("Layer 6",1);
        }
        if (Global.me.puzzle6)
        {
            emitter.SetParameter("Layer 7",1);
        }

        //puzzle.setParameterByName("Layer 1", 1);
        
        
    }
    
}
