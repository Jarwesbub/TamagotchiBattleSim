using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapControl : MonoBehaviour
{

    void Update()
    {

        if ((PersistentManagerScript.Instance.Lvl == 1) || (PersistentManagerScript.Instance.Lvl == 2))
        {
            PersistentManagerScript.Instance.WorldMapPos = 1;
            PersistentManagerScript.Instance.MapChange = 1;
        }

        if ((PersistentManagerScript.Instance.Lvl == 3) || (PersistentManagerScript.Instance.Lvl == 4))
        {
            PersistentManagerScript.Instance.WorldMapPos = 2;
            PersistentManagerScript.Instance.MapChange = 1;
        }

        if ((PersistentManagerScript.Instance.Lvl == 5) || (PersistentManagerScript.Instance.Lvl == 6))
        {
            PersistentManagerScript.Instance.WorldMapPos = 3;
            PersistentManagerScript.Instance.MapChange = 1;
        }

        if ((PersistentManagerScript.Instance.Lvl == 6) || (PersistentManagerScript.Instance.Lvl == 7))
        {
            PersistentManagerScript.Instance.WorldMapPos = 4;
            PersistentManagerScript.Instance.MapChange = 1;
        }

        if ((PersistentManagerScript.Instance.Lvl == 8) || (PersistentManagerScript.Instance.Lvl == 9))
        {
            PersistentManagerScript.Instance.WorldMapPos = 5;
            PersistentManagerScript.Instance.MapChange = 1;
        }

        if ((PersistentManagerScript.Instance.Lvl == 10))
        {
            PersistentManagerScript.Instance.WorldMapPos = 6;
            PersistentManagerScript.Instance.MapChange = 1;
        }

    }
}
