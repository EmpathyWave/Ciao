using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public StudioEventEmitter emitter;
    private bool start = false;
    public GameObject fader;
    public GameObject fader2;
    //public GameObject fader3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.anyKey)
        {
             
            fader.GetComponent<Fader>().Run(false,true);
            fader2.GetComponent<Fader>().Run(false,true);
            //fader3.GetComponent<Fader>().Run(false,true);
            start = true;
            //SceneManager.LoadScene("Main");
        }
        
        if(fader.GetComponent<Fader>().cg.alpha > .999f && start == true)
        {
            SceneManager.LoadScene("Main");
        }
        //fading starts here
    }
}
