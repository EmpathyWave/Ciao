using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class End : MonoBehaviour
{
    public float timer;
    public GameObject canvas;
    public GameObject text;
    public GameObject white;
    
    public float endTimer = 25f;

    public bool trueEnding = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.me.end)
        {
            endTimer -= Time.deltaTime;
            timer -= Time.deltaTime;
        }

        if (timer < 0 && trueEnding == false)
        {
            canvas.SetActive(true);
            text.GetComponent<Fader>().Run(true,false);
            white.GetComponent<Fader>().Run(true,false);
            trueEnding = true;
        }

        if (endTimer < 0 && trueEnding)
        {
            Application.Quit();
        }
    }
}
