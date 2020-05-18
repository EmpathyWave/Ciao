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
    
    //public float endTimer = f;

    public bool trueEnding = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.me.end)
        {
            timer -= Time.deltaTime;
            trueEnding = true;
        }

        if (timer < 0 && trueEnding)
        {
            Application.Quit();
        }
    }
}
