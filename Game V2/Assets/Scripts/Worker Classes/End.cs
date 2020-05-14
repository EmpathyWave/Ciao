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

        if (timer < 0)
        {
            canvas.SetActive(true);
            text.GetComponent<Fader>().Run(true,false);
            white.GetComponent<Fader>().Run(true,false);
        }

        if (endTimer < 0)
        {
            Application.Quit();
        }
    }
}
