using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSClass1 : MonoBehaviour
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
            PersistentManagerScript.Instance.Str = 13;
            PersistentManagerScript.Instance.Con = 12;
            PersistentManagerScript.Instance.Dex = 9;
            PersistentManagerScript.Instance.Agi = 9;
            PersistentManagerScript.Instance.Int = 8;
            PersistentManagerScript.Instance.Luck = 10;
            PersistentManagerScript.Instance.Wis = 10;

        }

    }
}
