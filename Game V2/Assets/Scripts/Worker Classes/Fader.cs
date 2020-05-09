using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public float timer;
    public float baseT = 1f;
    //public bool fadeIn = false;
    //public bool fadeOut = false;

    public CanvasGroup cg;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = baseT;
        cg = this.gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        //needs to be called, then when full it sets that to true, then fades out and then sets it to done
        //make  global, faded in and faded out bools
    }

    public void Run(bool fadeIn, bool fadeOut)
    {
        
        if (fadeIn)
        {
            StartCoroutine("FadeIn");
            fadeIn = false;
            //respond = true;
        }
        
        if (fadeOut)
        {
            StartCoroutine("FadeOut");
            fadeOut = false;
            //respond = true;
        }

    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            //Color c = rend.GetColor();
            cg.alpha = f;
            //rend.SetColor(c);
            
            yield return new WaitForSeconds(0.1f);
        }
        //Color d = rend.GetColor();
        //d.a = 1;
        cg.alpha = 1;
        //respond = true;
    }
    
    
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0; f -= 0.05f)
        {
            //Color c = rend.GetColor();
            cg.alpha = f;
            //rend.SetColor(c);
            
            yield return new WaitForSeconds(0.1f);
        }
        //Color d = rend.GetColor();
        //d.a = 0;
        cg.alpha = 0;
        //respond = true;
    }
}
