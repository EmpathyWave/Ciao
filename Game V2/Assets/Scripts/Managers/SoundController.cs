using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //public bool test;
    
    //add in puzzle theme
    //footsteps need the tutorial
    //add in hill area when it's in the game
    
    [FMODUnity.EventRef]
    [Header("Music")]
    public string Theme = " ";
    public bool playT;
    public bool stopT;
    FMOD.Studio.EventInstance theme;
    
    [FMODUnity.EventRef]
    [Header("Music")]
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
    
    
    [Header("Docks")]
    [FMODUnity.EventRef]
    public string Ocean = " ";
    public bool playOcean;
    public bool stopOcean;
    FMOD.Studio.EventInstance ocean;
    [FMODUnity.EventRef]
    public string Seagull = " ";
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
    public string Sweet = " ";
    public bool playSweet;
    FMOD.Studio.EventInstance sweet;
    
    
    //private FMOD.Studio.PLAYBACK_STATE playbackState;
    
    // Start is called before the first frame update
    void Start()
    {
        theme = FMODUnity.RuntimeManager.CreateInstance(Theme);
        pageTurn = FMODUnity.RuntimeManager.CreateInstance(PageTurn);
        addQ = FMODUnity.RuntimeManager.CreateInstance(AddQ);
        askQ = FMODUnity.RuntimeManager.CreateInstance(AskQ);
        textScroll = FMODUnity.RuntimeManager.CreateInstance(TextScroll);
        //textEnd = FMODUnity.RuntimeManager.CreateInstance(TextEnd);
        ocean = FMODUnity.RuntimeManager.CreateInstance(Ocean);
        //wind = FMODUnity.RuntimeManager.CreateInstance(Wind);
        seagull = FMODUnity.RuntimeManager.CreateInstance(Seagull);
        foutain = FMODUnity.RuntimeManager.CreateInstance(Foutain);
        chatter = FMODUnity.RuntimeManager.CreateInstance(Chatter);
        sweet = FMODUnity.RuntimeManager.CreateInstance(Sweet);
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
            textScroll.start();
            playAddQ = false;
        }
        if (stopTS)
        {
            textScroll.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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
        }

    }

    public bool PlayRnd(float low, float high)
    {
        float timer = Random.Range(low, high);
        while (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        return true;
    }
}
