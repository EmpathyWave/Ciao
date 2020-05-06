using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public float timerOne = 150f;
    public float timerTwo = 200f;
    public float timerThree = 400f;
    public float timerFour = 200f;
    public float timerFive = 150f;

    public bool line1Done = false;
    public bool line2Done = false;
    public bool line3Done = false;
    public bool line4Done = false;
    public bool line5Done = false;
    
    public String line1 = "Your father and I think it’s time for you to know your roots and visit your Uncle Lucca.";
    public String line2 = "I know you don’t know each other but I called him and he seems excited to see his niece, maybe he can bake you some of his famous focaccia!";
    public String line3 = "It’s a lovely little town, it will be nice to get away from the city for awhile. Your grandfather loved that place and you can visit the bakery and understand why it means so much to him. It’s been a long time since they spoke, hopefully you can be the reason for them to talk again.";
    public String line4 = "Your things are already at the hotel, it’s just a week so try to enjoy it while you can. Get acquainted with the town, everyone is very welcoming.";
    public String line5 = "I love you honey, get to know the town. Try to get that focaccia recipe!";

    public GameObject sounds;
    public GameObject box;
    public GameObject background;
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Awake()
    {
        //sounds.GetComponent<SoundController>().playP = true;
        canvas.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        box.gameObject.SetActive(true);
        box.GetComponent<TypingEffect>().text = line1;
        StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
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
                StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line2;
            }
        }
        
        if (line1Done == true && line2Done == false)
        {
            StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerTwo -= Time.deltaTime;
            if (timerTwo < 0)
            {
                line2Done = true;
                StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line3;
            }
        }
        
        if (line2Done == true && line3Done == false)
        {
            StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerThree -= Time.deltaTime;
            if (timerThree < 0)
            {
                line3Done = true;
                StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line4;
            }
        }
        
        if (line3Done == true && line4Done == false)
        {
            StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerFour -= Time.deltaTime;
            if (timerFour < 0)
            {
                line4Done = true;
                StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = line5;
            }
        }
        
        if (line4Done == true && line5Done == false)
        {
            StartCoroutine(box.GetComponent<TypingEffect>().AnimateText());
            timerFive -= Time.deltaTime;
            if (timerFive < 0)
            {
                line5Done = true;
                StopCoroutine(box.GetComponent<TypingEffect>().AnimateText());
                box.GetComponent<TypingEffect>().text = " ";
                sounds.GetComponent<SoundController>().playT = false;
            }
        }
        
    }
}
