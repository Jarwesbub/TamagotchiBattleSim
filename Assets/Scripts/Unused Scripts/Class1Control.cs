using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class1Control : MonoBehaviour
{
    //public static Class1Control Instance { get; set; }

    public int AttackDamage;
    public int GetDamage;

    public int CriticalHit;
    public int Randomizer100 = 100;

    public bool IsCritical = false;

    private int STR, CON, DEX, AGI, INT, LUCK, CHA, WIS;


    public GameObject CriticalHit_Object;

    //public int dmgBuff;

    void Start()
    {
        STR = PersistentManagerScript.Instance.Str;
        CON = PersistentManagerScript.Instance.Con;
        DEX = PersistentManagerScript.Instance.Dex;
        AGI = PersistentManagerScript.Instance.Agi;
        INT = PersistentManagerScript.Instance.Int;
        LUCK = PersistentManagerScript.Instance.Luck;
        CHA = PersistentManagerScript.Instance.Cha;
        WIS = PersistentManagerScript.Instance.Wis;

        

        CriticalHit = PersistentManagerScript.Instance.CritHit;
    }




    void Update()
    {
        //CriticalHit = LUCK / 4; //(2-5% chance)
        CriticalHit = PersistentManagerScript.Instance.CritHit;

        if (Input.GetKeyDown("i"))
        {
            MakeDamageToClass1();
        }


        if (Input.GetKeyDown("o"))
        {
            MakeDamageToClass2();
        }

        if (Input.GetKeyDown("p"))
        {
            MakeDamageToClass3();
        }
        /*
        if (Input.GetKeyDown("c")) // Critical hit randomizer
        {
            CriticalHitChance();

        }
        */

    }

    public void CriticalHitChance()
    {
        Randomizer100 = 100; // randomizer variable
        Randomizer100 = Random.Range(0, 100); // Random number from 0 to 100

        if (Randomizer100 <= CriticalHit+1)
        {
            Debug.Log("CRITICAL HIT");

            IsCritical = true;
            CriticalHit_Object.SetActive(true);

        }
        else
        {
            IsCritical = false;
            CriticalHit_Object.SetActive(false);
        }
    }


    public void MakeDamageToClass1()
    {

        if (IsCritical == true)
        {
            AttackDamage = STR * 2;
        }
        else
        {
            AttackDamage = STR; // normal damage
        }
    }



    public void MakeDamageToClass2()
    {
        if (IsCritical == true)
        {
            AttackDamage = (STR * 4 / 3) * 2; // adds 25% damage buff
        }
        else
        {
            AttackDamage = STR * 4 / 3; // adds 25% damage buff
        }



    }

    public void MakeDamageToClass3()
    {
        if (IsCritical == true)
        {
            AttackDamage = (STR / 4 * 3) * 2; // adds 25% damage buff
        }
        else
        {
            AttackDamage = STR / 4 * 3; // normal damage
        }




        

    }

}
