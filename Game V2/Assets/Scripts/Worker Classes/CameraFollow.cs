using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject girl;        //Public variable to store a reference to the player game object
    

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - girl.transform.position;
    }

    void Update()
    {
        if (Global.me.moving && Global.me.currentLocation == Global.LocationState.Hills)
        {
            transform.position = new Vector3(-630.6324f, 228.852f, -9.91f);
        }

        if ((Global.me.currentLocation == Global.LocationState.Hills) && (girl.transform.position.x > -630.7705))
        {
            transform.position = girl.transform.position + offset;
        }
        
        if ((Global.me.currentLocation == Global.LocationState.Docks) && (girl.transform.position.x > -673))
        {
            transform.position = girl.transform.position + offset;
        }
        
        if ((Global.me.currentLocation == Global.LocationState.Piazza) && ((girl.transform.position.x > -674.4295) && (girl.transform.position.x < -652.57)))
        {
            transform.position = girl.transform.position + offset;
        }

    }
    

}
