﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyClass2AttDef : MonoBehaviour
{

    public int EnLVL = 1;
    public int EnHealth = 100;
    public int EnStr;

    // DmgCalc = Damage that is done to player or enemy. DmgCalcWaitTime = Time that stat is shown
    int DmgCalc = 0;
    float DmgCalcTime = 0.5f; // chance values if needed

    public bool PlayerDefUP = false;

    public int EnAgi;
    public int EnDex;
    public int EnInt;
    public int EnCon;

    public bool EnemyTurn; // Who is doing attack first -> false = player, true = enemy




    //Player's stats
    public int PlayerClass;
    public int PlayerHealth;

    private int STR, CON, DEX, AGI, INT, LUCK, CHA, WIS;

    int KeepValue; // Holds value for math calculations
    int KeepValue1; // Holds Critical hit values!!!
    int KeepValue2;
    int KeepValue3;

    int KeepEnStr; // Holds enemy stats for status effects
    int KeepEnDex;
    int KeepEnInt;


    int STRBuff, STRNerf, DEXBuff, DEXNerf, INTBuff, INTNerf; // Stats buff/nerf when attacking different Class foe

    int EnStrBuff, EnStrNerf, EnDexBuff, EnDexNerf, EnIntBuff, EnIntNerf; // Stats buff/nerf when attacking different Class foe


    // shows player and enemy damages calculated
    public Text DmgDoneTxt;
    public Text DmgTakenTxt;

    //private bool CollisionCheck = false; // testausta

    public GameObject myParentObject;

    public Text EnHealthTxt;
    public Text EnStrTxt;
    public Text EnDexTxt;
    public Text EnIntTxt;
    public Text EnConTxt;
    public Text EnAgiTxt;
    public Text EnLVLTxt;

    // Timing stuff here:
    float TurnStartTime = 0.2f;
    float TurnEndTime = 1f;

    float EnemyDeathTime = 3f;

    float SpawnPosX = 3;
    float SpawnPosY = 0;

    // -> When enemy dies timing -> IEnumerator EnemyDeath()


    void Start()
    {
        GetPlayerStats();


        PersistentManagerScript.Instance.XPScreen = 0;

        ClassBuffNerf();
    }

    void ClassBuffNerf()
    {
        STRBuff = STR + (STR / 4); // Player Strength get 25% buff
        STRNerf = STR - (STR / 4); // Player Strength get 25% nerf

        DEXBuff = DEX + (DEX / 4); // Player Strength get 25% buff
        DEXNerf = DEX - (DEX / 4); // Player Strength get 25% nerf

        INTBuff = INT + (INT / 4); // Player Strength get 25% buff
        INTNerf = INT - (INT / 4); // Player Strength get 25% nerf

        EnStrBuff = EnStr + (EnStr / 4);
        EnStrNerf = EnStr - (EnStr / 4);

        EnDexBuff = EnDex + (EnDex / 4);
        EnDexNerf = EnDex - (EnDex / 4);

        EnIntBuff = EnInt + (EnInt / 4);
        EnIntNerf = EnInt - (EnInt / 4);

    }

    void GetPlayerStats()
    {
        PlayerHealth = PersistentManagerScript.Instance.PlayerHealth;

        PlayerClass = PersistentManagerScript.Instance.PlayerClass;
        STR = PersistentManagerScript.Instance.Str;
        CON = PersistentManagerScript.Instance.Con;
        DEX = PersistentManagerScript.Instance.Dex;
        AGI = PersistentManagerScript.Instance.Agi;
        INT = PersistentManagerScript.Instance.Int;
        LUCK = PersistentManagerScript.Instance.Luck;
        CHA = PersistentManagerScript.Instance.Cha;
        WIS = PersistentManagerScript.Instance.Wis;

        EnLVL = PersistentManagerScript.Instance.Lvl;

        KeepValue = 0;
        KeepValue1 = 0;
        KeepValue2 = 0;
        KeepValue3 = 0;

        KeepEnStr = 0;
        KeepEnDex = 0;
        KeepEnInt = 0;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GetPlayerStats();
        PersistentManagerScript.Instance.XPScreen = 0;
        transform.SetParent(myParentObject.transform);
        transform.position = new Vector2(SpawnPosX, SpawnPosY);
        PersistentManagerScript.Instance.FightScreen = true;

        StartCoroutine(FightStart());

    }



    void DrawEnStats()
    {
        EnHealthTxt.text = EnHealth.ToString();
        EnHealthTxt.text = "HP      " + EnHealthTxt.text;

        EnStrTxt.text = EnStr.ToString();
        EnStrTxt.text = "Str      " + EnStrTxt.text;

        EnConTxt.text = EnCon.ToString();
        EnConTxt.text = "Con     " + EnConTxt.text;

        EnAgiTxt.text = EnAgi.ToString();
        EnAgiTxt.text = "Agi      " + EnAgiTxt.text;

        EnDexTxt.text = EnDex.ToString();
        EnDexTxt.text = "Dex     " + EnDexTxt.text;

        EnIntTxt.text = EnCon.ToString();
        EnIntTxt.text = "Int       " + EnIntTxt.text;

        EnLVL = PersistentManagerScript.Instance.Lvl;

        EnLVLTxt.text = EnLVL.ToString();
        EnLVLTxt.text = ("Level ") + EnLVLTxt.text + (" (Rogue)");

    }

    void PlayerDamageDone()
    {
        DmgCalc -= EnHealth;

        DmgDoneTxt.text = DmgCalc.ToString();
        DmgDoneTxt.text = "-" + DmgDoneTxt.text;


    }

    void PlayerDamageTaken()
    {
        DmgCalc -= PlayerHealth;

        DmgTakenTxt.text = DmgCalc.ToString();
        DmgTakenTxt.text = "-" + DmgTakenTxt.text;
    }

    /// <summary>
    /// -------------------------------------------------------------------------------------------------------------------
    /// </summary>

    void Update()
    {



        DrawEnStats();


        if (PersistentManagerScript.Instance.PlayerTurn == true && PersistentManagerScript.Instance.BasicAttack == true)
        {

            if (PersistentManagerScript.Instance.BasicAttack == true)
            {
                PersistentManagerScript.Instance.BasicAttack = false;
                GetPlayerStats();
                StartCoroutine(EnemyGetDamage1());

                PersistentManagerScript.Instance.PlayerTurn = false;
            }
        }


        if (PersistentManagerScript.Instance.PlayerTurn == true && PersistentManagerScript.Instance.BasicDefense == true)
        {

            if (PersistentManagerScript.Instance.BasicDefense == true)
            {
                PersistentManagerScript.Instance.BasicDefense = false;
                GetPlayerStats();
                StartCoroutine(PlayerBasicDefense());

                PersistentManagerScript.Instance.PlayerTurn = false;
            }
        }

        /*
        if (PersistentManagerScript.Instance.BasicDefense == true)
         {
             GetPlayerStats();

             PersistentManagerScript.Instance.BasicDefense = false;
         }
         */

        if (PersistentManagerScript.Instance.EnemyTurn == true && PersistentManagerScript.Instance.PlayerTurn == false) // Enemy Automatic attack
        {
            StartCoroutine(EnemyBasicAttack());
            PersistentManagerScript.Instance.EnemyTurn = false;
        }



        if (EnHealth <= 0)
        {

            StartCoroutine(EnemyDeath());
        }


    }

    IEnumerator FightStart()
    {


        PersistentManagerScript.Instance.IsCritical = false;
        PersistentManagerScript.Instance.EnemyTurn = false;
        PersistentManagerScript.Instance.PlayerTurn = false;

        yield return new WaitForSeconds(1f);

        if (PersistentManagerScript.Instance.Agi >= EnAgi)
        {
            PersistentManagerScript.Instance.EnemyTurn = false;
            PersistentManagerScript.Instance.PlayerTurn = true;
        }
        if (PersistentManagerScript.Instance.Agi <= EnAgi)
        {
            PersistentManagerScript.Instance.EnemyTurn = true;
            PersistentManagerScript.Instance.PlayerTurn = false;


        }




    }


    IEnumerator EnemyDeath() // When Enemy dies -> Fightscreen ends -> go to world screen
    {

        yield return new WaitForSeconds(DmgCalcTime);
        DmgTakenTxt.text = " ";
        PersistentManagerScript.Instance.XPScreen = 1;

        yield return new WaitForSeconds(EnemyDeathTime);

        PersistentManagerScript.Instance.XPScreen = 0;
        PersistentManagerScript.Instance.PlayerTurn = false;
        PersistentManagerScript.Instance.FightScreen = false;
        Destroy(gameObject);
    }


    public void CriticalHitClac()
    {
        KeepValue1 = STR;
        KeepValue2 = DEX;
        KeepValue3 = INT;

        if (PersistentManagerScript.Instance.IsCritical == true)
        {
            STR = STR * 2;
            DEX = DEX * 2;
            INT = INT * 2;

        }
        else
        {
            STR = KeepValue1;
            DEX = KeepValue2;
            INT = KeepValue3;
        }

    }
    IEnumerator PlayerBasicDefense()
    {
        // If Defense button is used -> Skip attack buff defense

        // Code added in EnemyBasicAttack()
        yield return new WaitForSeconds(TurnEndTime);
        {
            PlayerDefUP = true;

            PersistentManagerScript.Instance.EnemyTurn = true;

        }

    }


    IEnumerator EnemyGetDamage1() // Defense added too
    {



        if (EnHealth >= 0 && PersistentManagerScript.Instance.EnemyTurn == false)
        {
            PersistentManagerScript.Instance.StartRandomCrit = true;

            yield return new WaitForSeconds(TurnStartTime);



            if (PlayerClass == 1) // Basic Attack from Class1 to Class2
            {
                CriticalHitClac();
                ClassBuffNerf();

                if (STRBuff >= EnCon)
                {
                    DmgCalc = EnHealth;
                    EnHealth -= STRBuff - EnCon;

                    PlayerDamageDone();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgDoneTxt.text = " ";
                }
                else
                {

                    Debug.Log("No Damage");
                }


            }

            if (PlayerClass == 2) // Basic Attack from Class2 to Class2
            {
                CriticalHitClac();
                ClassBuffNerf();

                if (DEX >= (EnCon))
                {
                    DmgCalc = EnHealth;
                    EnHealth -= DEX - (EnCon);
                    PlayerDamageDone();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgDoneTxt.text = " ";

                }
                else
                {
                    Debug.Log("No Damage");
                }


            }

            if (PlayerClass == 3) // Basic Attack from Class3  to Class2
            {
                CriticalHitClac();
                ClassBuffNerf();

                if (INTNerf >= EnCon)
                {
                    DmgCalc = EnHealth;
                    EnHealth -= INTNerf - EnCon;
                    PlayerDamageDone();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgDoneTxt.text = " ";

                }
                else
                {
                    Debug.Log("No Damage");
                }


            }
            yield return new WaitForSeconds(TurnEndTime);
            {
                PersistentManagerScript.Instance.EnemyTurn = true;

            }
        }



    }


    IEnumerator EnemyBasicAttack()
    {
        //PersistentManagerScript.Instance.BasicAttack = false;
        if (PlayerDefUP == true)
        {
            KeepEnStr = EnStr;
            KeepEnDex = EnDex;
            KeepEnInt = EnInt;


            EnStr = (EnStr / 4) * 3; // Defense buff 30% (enemy strength down for next attack)
            EnDex = (EnDex / 4) * 3;
            EnInt = (EnInt / 4) * 3;
        }


        if (EnHealth >= 0)
        {
            yield return new WaitForSeconds(TurnStartTime);

            ClassBuffNerf();

            if (PlayerClass == 1)
            {

                {
                    if (EnDexNerf >= CON)
                    {
                        DmgCalc = PlayerHealth;
                        PlayerHealth -= EnDexNerf - CON;
                        PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                        PlayerDamageTaken();
                        yield return new WaitForSeconds(DmgCalcTime);
                        DmgTakenTxt.text = " ";

                    }
                    if (CON >= EnDexNerf)
                    {
                        DmgCalc = PlayerHealth;
                        PlayerHealth -= 1;
                        PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                        PlayerDamageTaken();
                        yield return new WaitForSeconds(DmgCalcTime);
                        DmgTakenTxt.text = " ";
                    }

                }
            }

            if (PlayerClass == 2)
            {


                if (EnDex >= CON)
                {
                    DmgCalc = PlayerHealth;
                    PlayerHealth -= EnDex - CON;
                    PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                    PlayerDamageTaken();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgTakenTxt.text = " ";
                }
                if (CON >= EnDex)
                {
                    DmgCalc = PlayerHealth;
                    PlayerHealth -= 1;
                    PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                    PlayerDamageTaken();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgTakenTxt.text = " ";
                }



            }

            if (PlayerClass == 3)
            {


                if (EnDexBuff >= CON)
                {
                    DmgCalc = PlayerHealth;
                    PlayerHealth -= EnDexBuff - CON;
                    PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                    PlayerDamageTaken();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgTakenTxt.text = " ";
                }
                if (CON >= EnDexBuff)
                {
                    DmgCalc = PlayerHealth;
                    PlayerHealth -= 1;
                    PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                    PlayerDamageTaken();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgTakenTxt.text = " ";
                }



            }


        }
        if (PlayerDefUP == true)
        {
            EnStr = KeepEnStr;
            EnDex = KeepEnDex;
            EnInt = KeepEnInt;

            PlayerDefUP = false;
            PersistentManagerScript.Instance.BasicDefense = false;
        }





        //TurnEndTime = TurnEndTimeSeconds;
        yield return new WaitForSeconds(TurnEndTime);
        {
            PersistentManagerScript.Instance.PlayerTurn = true;

        }

    }


}

