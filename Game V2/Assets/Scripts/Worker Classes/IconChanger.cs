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
            Run();
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
            if (girl.GetComponent<Walking>().currentChar.tag == "Bartender")
            {
                if (i == 1)
                {
                    icons[1].gameObject.SetActive(true);
                }
                else
                {
                    icons[i].gameObject.SetActive(false);
                }
            }
            if (girl.GetComponent<Walking>().currentChar.tag == "EmiliaCardello")
            {
                if (i == 2)
                {
                    icons[2].gameObject.SetActive(true);
                }
                else
                {
                    icons[i].gameObject.SetActive(false);
                }
            }
            if (girl.GetComponent<Walking>().currentChar.tag == "UncleLucca")
            {
                if (i == 3)
                {
                    icons[3].gameObject.SetActive(true);
                }
                else
                {
                    icons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
