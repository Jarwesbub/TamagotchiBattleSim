using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightEnd : MonoBehaviour
{
    public GameObject parentObject;
    int childs;


    public void RunButton()
    {
        StartCoroutine(RunWait());


    }
    IEnumerator RunWait()
    {
        PersistentManagerScript.Instance.PlayerTurn = false;
        PersistentManagerScript.Instance.EnemyTurn = true;
        yield return new WaitForSeconds(1.5f);

        PersistentManagerScript.Instance.Run = true;

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        
        PersistentManagerScript.Instance.EnDies = 2;
        PersistentManagerScript.Instance.XPScreen = 0;
        PersistentManagerScript.Instance.PlayerTurn = false;
        PersistentManagerScript.Instance.EnemyTurn = false;
        PersistentManagerScript.Instance.FightScreen = false;


    }


    // Update is called once per frame
    void LateUpdate()
    {

        if (PersistentManagerScript.Instance.FightScreen == false)
        {

            //Destroy(parentObject.transform.GetChild(0).gameObject);
            
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

        }
    }




}
