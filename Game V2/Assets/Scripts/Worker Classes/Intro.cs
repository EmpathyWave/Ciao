using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    private float timerOne = 7f;
    private float timerTwo = 10f;
    private float timerThree = 10f;
    private float timerFour = 11.5f;
    private float timerFive = 10f;
    private float timerSix = 10f;

    public bool line1Done = false;
    public bool line2Done = false;
    public bool line3Done = false;
    public bool line4Done = false;
    public bool line5Done = false;
    public bool line6Done = false;
    
    private String line1 = "Your father and I think it’s time for you to know your roots and visit your Uncle Lucca.";
    private String line2 = "I know you don’t know each other, but I called him and he seems excited to see his niece!\n \nMaybe he can bake you some of his famous focaccia!";
    private String line3 = "It’s a lovely little town, it will be nice to get away from the city for awhile.\n \n Your grandfather grew up there and you can visit the old bakery he helped start....";
    private String line4 = "It’s been a long while since Uncle Lucca and your grandfather spoke.\n \nYou'll learn why in time.";
    private String line5 = "Your things are already at the hotel. And remember! It’s just a week so try to enjoy it while you can.\n \nGet acquainted with the town, everyone is super friendly!";
    private String line6 = "I love you, sweetie.\n \nTry to get that focaccia recipe!";

    //public GameObject sounds;
    public GameObject box;
    public GameObject background;
    public GameObject canvas;

    public bool done = false;
    // Start is called before the first frame update
    void Awake()
    {
        //sounds.GetComponent<SoundController>().playP = true;
        canvas.SetActive(true);
        background.SetActive(true);
        box.SetActive(true);
        box.GetComponent<TypingEffect>().text = line1;
        //StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
    }

    // Update is called once per frame
    void Update()
    {
        if (line1Done == false && line2Done == false)
        {
            timerOne -= Time.deltaTime;
            if (timerOne < 0)
            {
                line1Done = true;
                //StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line2;
            }
        }
        
        if (line1Done == true && line2Done == false)
        {
            //StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerTwo -= Time.deltaTime;
            if (timerTwo < 0)
            {
                line2Done = true;
                //StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line3;
            }
        }
        
        if (line2Done == true && line3Done == false)
        {
            //StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerThree -= Time.deltaTime;
            if (timerThree < 0)
            {
                line3Done = true;
                //StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line4;
            }
        }
        
        if (line3Done == true && line4Done == false)
        {
            //StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerFour -= Time.deltaTime;
            if (timerFour < 0)
            {
                line4Done = true;
                //StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line5;
            }
        }
        
        if (line4Done == true && line5Done == false)
        {
            //StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerFive -= Time.deltaTime;
            if (timerFive < 0)
            {
                line5Done = true;
                //StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line6;
                //sounds.GetComponent<SoundController>().playT = false;
            }
        }
        
        if (line5Done == true && line6Done == false)
        {
            //StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerSix -= Time.deltaTime;
            if (timerSix < 0)
            {
                line6Done = true;
                //StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                //box.GetComponent<TypingEffect>().text = " ";
                box.GetComponent<Fader>().Run(false, true);
                background.GetComponent<Fader>().Run(false, true);
                
                //sounds.GetComponent<SoundController>().playT = false;
            }
        }
        if (background.GetComponent<Fader>().cg.alpha < .001f && done == false)
        {
            canvas.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
            box.gameObject.SetActive(false);
            Global.me.currentGS = Global.GameState.Walking;
            this.GetComponent<Intro>().enabled = false;
        }
        
        
    }
}
