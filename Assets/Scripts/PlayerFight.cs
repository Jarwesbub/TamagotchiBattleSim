using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject FightClass1;
    public GameObject FightClass2;
    public GameObject FightClass3;

    public float FightPosX;
    public float FightPosY;
    public float FightPosZ;

    public int Player = 0;


    void Start()
    {
        Player = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.Run == true)
        {
            Player = 0;
            PersistentManagerScript.Instance.Run = false;
        }

        for (int i = Player; i < 1; i++)
        {

            if (PersistentManagerScript.Instance.PlayerClass == 1 && PersistentManagerScript.Instance.FightScreen == true)
            {
                var player = Instantiate(FightClass1, new Vector3(FightPosX, FightPosY, FightPosZ), Quaternion.identity);
                player.transform.SetParent(parentObject.transform);
                player.SetActive(true);

                Player += 1;
            }

            if (PersistentManagerScript.Instance.PlayerClass == 2 && PersistentManagerScript.Instance.FightScreen == true)
            {
                var player = Instantiate(FightClass2, new Vector3(FightPosX, FightPosY, FightPosZ), Quaternion.identity);
                player.transform.SetParent(parentObject.transform);
                player.SetActive(true);

                Player += 1;
            }

            if (PersistentManagerScript.Instance.PlayerClass == 3 && PersistentManagerScript.Instance.FightScreen == true)
            {
                var player = Instantiate(FightClass3, new Vector3(FightPosX, FightPosY, FightPosZ), Quaternion.identity);
                player.transform.SetParent(parentObject.transform);
                player.SetActive(true);

                Player += 1;
            }

        }


        /*
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
        */
    }
    void LateUpdate()
    {

        if (PersistentManagerScript.Instance.FightScreen == false)
        {

            //Destroy(parentObject.transform.GetChild(0).gameObject);

            Player = 0;
        }
    }
    

}
