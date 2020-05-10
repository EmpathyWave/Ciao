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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.anyKey)
        {
            emitter.SetParameter("EndMain",1); 
            fader.GetComponent<Fader>().Run(true,false);
            start = true;
            //SceneManager.LoadScene("Main");
        }
        if(fader.GetComponent<Fader>().cg.alpha > .99f && start == true)
        {
            SceneManager.LoadScene("Main");
        }
        
    }
}
