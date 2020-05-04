using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    public GameObject FightClass1;
    public GameObject FightClass2;
    public GameObject FightClass3;




    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.PlayerClass == 1)
        {
            FightClass1.SetActive(true);
        }
        else
        {
            FightClass1.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PlayerClass == 2)
        {
            FightClass2.SetActive(true);
        }
        else
        {
            FightClass2.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PlayerClass == 3)
        {
            FightClass3.SetActive(true);
        }
        else
        {
            FightClass3.SetActive(false);
        }
    }
}
