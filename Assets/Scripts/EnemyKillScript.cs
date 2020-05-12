using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
//using System.Diagnostics;
using UnityEngine;

public class EnemyKillScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {


    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (PersistentManagerScript.Instance.EnDies == 1)
        {
            
            StartCoroutine(EnemyDeathWait());
        }
        
        // If object gets multiple childobjects -> destroy (1 child max at the time)
        for (int i = 1; i < transform.childCount; i++)
        {
            Debug.Log("Too many childs");
            Destroy(transform.GetChild(i).gameObject);
        }

        //if (PersistentManagerScript.Instance.EnDies == 2)
        if (PersistentManagerScript.Instance.Run == true)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            PersistentManagerScript.Instance.EnDies = 0;
            PersistentManagerScript.Instance.XPScreen = 0;
            PersistentManagerScript.Instance.PlayerTurn = false;
            PersistentManagerScript.Instance.Run = false;
            PersistentManagerScript.Instance.FightScreen = false;
        }
        

    }



    IEnumerator EnemyDeathWait()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        PersistentManagerScript.Instance.EnDies = 0;

        yield return new WaitForSeconds(2f);
        
        PersistentManagerScript.Instance.XPScreen = 0;
        PersistentManagerScript.Instance.PlayerTurn = false;
        PersistentManagerScript.Instance.FightScreen = false;
        
    }

}
