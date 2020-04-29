using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSClass3 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        if (PersistentManagerScript.Instance.GameStart == true)
        {
            PersistentManagerScript.Instance.Lvl = 1;
            PersistentManagerScript.Instance.GameStart = false;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.Lvl == 1)
        {
            PersistentManagerScript.Instance.Str = 10;
            PersistentManagerScript.Instance.Con = 9;
            PersistentManagerScript.Instance.Dex = 8;
            PersistentManagerScript.Instance.Agi = 9;
            PersistentManagerScript.Instance.Int = 13;
            PersistentManagerScript.Instance.Luck = 10;

        }

    }
}
