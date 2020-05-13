using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconChanger : MonoBehaviour
{
    public GameObject[] icons;
    public GameObject girl;
   
    // Update is called once per frame
    void Update()
    {
        if (Global.me.currentGS == Global.GameState.Selecting)
        {
            
        }
    }

    void Run()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (girl.GetComponent<Walking>().currentChar.tag == "CafeOwner")
            {
                if (i == 0)
                {
                    icons[0].gameObject.SetActive(true);
                }
                else
                {
                    icons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
