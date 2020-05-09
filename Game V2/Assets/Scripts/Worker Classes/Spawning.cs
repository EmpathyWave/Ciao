using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject girl;
    public Transform docks;
    public Transform hills;
    public Transform piazza;
    public GameObject sounds;

    public float timer1;
    public float timer2;
    
    void Start()
    {
        timer1 = Random.Range(3f, 8f);
        timer2 = Random.Range(3f, 8f);
    }
    
    void Update()
    {
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Docks) //dockss
        {
            sounds.GetComponent<SoundController>().stopFoutain = true;
            sounds.GetComponent<SoundController>().stopChatter = true;
            sounds.GetComponent<SoundController>().stopEnviro = true;
            sounds.GetComponent<SoundController>().playOcean = true;
            timer1 = Random.Range(3f, 8f);
            timer2 = Random.Range(3f, 8f);
            girl.transform.position = docks.position;
            Global.me.moving = false;
        }
        
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Hills) //hillss
        {
            sounds.GetComponent<SoundController>().stopFoutain = true;
            sounds.GetComponent<SoundController>().stopChatter = true;
            sounds.GetComponent<SoundController>().stopOcean = true;
            sounds.GetComponent<SoundController>().playEnviro = true;
            timer1 = Random.Range(3f, 8f);
            timer2 = Random.Range(3f, 8f);
            //sounds.GetComponent<SoundController>().stopOcean = true;
            girl.transform.position = hills.position;
            Global.me.moving = false;
        }
        
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Piazza) //pizzaaa time
        {
            sounds.GetComponent<SoundController>().playFoutain = true;
            sounds.GetComponent<SoundController>().playChatter = true;
            sounds.GetComponent<SoundController>().stopEnviro = true;
            sounds.GetComponent<SoundController>().stopOcean = true;
            timer1 = Random.Range(3f, 8f);
            timer2 = Random.Range(3f, 8f);
            girl.transform.position = piazza.position;
            Global.me.moving = false;
        }

        if (Global.me.currentLocation == Global.LocationState.Piazza)
        {
            timer1 -= Time.deltaTime;
            //timer2 -= Time.deltaTime;
            Debug.Log("random play");
            if (timer1 < 0)
            {
                sounds.GetComponent<SoundController>().playSweet = true;
                timer1 = Random.Range(20f, 35f);
            }
        }

        if (Global.me.currentLocation == Global.LocationState.Hills)
        {
            Debug.Log("random play");
            timer1 -= Time.deltaTime;
            timer2 -= Time.deltaTime;
            if (timer1 < 0)
            {
                sounds.GetComponent<SoundController>().playSweeties = true;
                timer1 = Random.Range(15f, 27f);
            }
            if (timer2 < 0)
            {
                sounds.GetComponent<SoundController>().playBirds = true;
                timer2 = Random.Range(5f, 17f);
            }
            //sounds.GetComponent<SoundController>().playSweeties = sounds.GetComponent<SoundController>().PlayRnd(12f,20f);
            //sounds.GetComponent<SoundController>().playBirds = sounds.GetComponent<SoundController>().PlayRnd(5f,25f);
        }

        if (Global.me.currentLocation == Global.LocationState.Docks)
        {
            timer1 -= Time.deltaTime;
            //timer2 -= Time.deltaTime;
            if (timer1 < 0)
            {
                sounds.GetComponent<SoundController>().playSeagull = true;
                timer1 = Random.Range(3f, 7f);
            }
        }
    }
}
