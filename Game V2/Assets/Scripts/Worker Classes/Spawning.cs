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
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Docks) //dockss
        {
            sounds.GetComponent<SoundController>().stopFoutain = true;
            sounds.GetComponent<SoundController>().stopChatter = true;
            sounds.GetComponent<SoundController>().playOcean = true;
            girl.transform.position = docks.position;
            Global.me.moving = false;
        }
        
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Hills) //hillss
        {
            sounds.GetComponent<SoundController>().stopFoutain = true;
            sounds.GetComponent<SoundController>().stopChatter = true;
            sounds.GetComponent<SoundController>().stopOcean = true;
            girl.transform.position = hills.position;
            Global.me.moving = false;
        }
        
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Piazza) //pizzaaa time
        {
            sounds.GetComponent<SoundController>().playFoutain = true;
            sounds.GetComponent<SoundController>().playChatter = true;
            sounds.GetComponent<SoundController>().stopOcean = true;
            girl.transform.position = piazza.position;
            Global.me.moving = false;
        }
    }
}
