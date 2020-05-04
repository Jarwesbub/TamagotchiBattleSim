using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsController : MonoBehaviour
{
    //public int XPScreen;
    //public bool EnemyTurn = false;

    public GameObject FightXPScreen;
    public GameObject PlayerTurn;

    public GameObject CritHitObject;

    void Update()
    {
        if (PersistentManagerScript.Instance.IsCritical == true)
        {
            CritHitObject.SetActive(true);

        }
        if (PersistentManagerScript.Instance.IsCritical == false)
        {
            CritHitObject.SetActive(false);
        }

        //XPScreen = PersistentManagerScript.Instance.XPScreen;
        //XPScreen = PersistentManagerScript.Instance.XPScreen;
        //EnemyTurn = PersistentManagerScript.Instance.EnemyTurn;

        if (PersistentManagerScript.Instance.PlayerTurn == true && PersistentManagerScript.Instance.XPScreen == 0)
        {
            PlayerTurn.SetActive(true);

        }
        else
        {
            PlayerTurn.SetActive(false);

        }


        if (PersistentManagerScript.Instance.XPScreen == 1)
        {
            FightXPScreen.SetActive(true);   

        }
        else
        {
            FightXPScreen.SetActive(false);

        }







        /*
        if (Input.GetKeyDown("space"))
        {
                PersistentManagerScript.Instance.LvlGet = true;
                PersistentManagerScript.Instance.Lvl += 1;
        }
        */


        //Testing PlayerClasses from 1-3
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            PersistentManagerScript.Instance.PlayerClass = 1;
            PersistentManagerScript.Instance.Lvl = 1;

        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            PersistentManagerScript.Instance.PlayerClass = 2;
            PersistentManagerScript.Instance.Lvl = 1;

        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            PersistentManagerScript.Instance.PlayerClass = 3;
            PersistentManagerScript.Instance.Lvl = 1;

        }
        

    }
    
}
