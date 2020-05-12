using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatHealthControl : MonoBehaviour
{



    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            PersistentManagerScript.Instance.PlayerHealth += 20;

        }
        if (Input.GetKeyDown("m"))
        {
            PersistentManagerScript.Instance.PlayerMana += 20;

        }


    }
}
