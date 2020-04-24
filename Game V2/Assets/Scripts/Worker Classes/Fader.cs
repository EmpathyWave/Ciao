using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public float timer;
    public float baseT = 1f;
    //public bool fadeIn = false;
    //public bool fadeOut = false;

    private SpriteRenderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = baseT;
        rend = this.gameObject.GetComponent<SpriteRenderer>();
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

        if (rend.material.color.a == 1 && fadeIn)
        {
            fadeIn = false;
            StopCoroutine("FadeIn");
            //stop all coroutines
            //continue thing
        }

        if (rend.material.color.a == 0 && fadeOut)
        {
            fadeIn = false;
            StopCoroutine("FadeOut");
        }
            
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            
            yield return new WaitForSeconds(0.1f);
        }
        Color d = rend.material.color;
        d.a = 1;
        rend.material.color = d;
        //respond = true;
    }
    
    
    
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            
            yield return new WaitForSeconds(0.1f);
        }
        Color d = rend.material.color;
        d.a = 0;
        rend.material.color = d;
        //respond = true;
    }
}
