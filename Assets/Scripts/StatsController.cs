using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        //PersistentManagerScript.Instance.Lvl
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

                PersistentManagerScript.Instance.LvlGet = true;
                PersistentManagerScript.Instance.Lvl += 1;
            

        }


        //Testing PlayerClasses from 1-3, using keys z,x,c
        if (Input.GetKeyDown("z"))
        {
            PersistentManagerScript.Instance.PlayerClass = 1;
            PersistentManagerScript.Instance.Lvl = 1;

        }

        if (Input.GetKeyDown("x"))
        {
            PersistentManagerScript.Instance.PlayerClass = 2;
            PersistentManagerScript.Instance.Lvl = 1;

        }

        if (Input.GetKeyDown("c"))
        {
            PersistentManagerScript.Instance.PlayerClass = 3;
            PersistentManagerScript.Instance.Lvl = 1;

        }

    }
}
