using System.Collections;
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
    int KeepEnAgi;

    int WeakEnStr; // Holds enemy stats in Weakness status effect
    int WeakEnDex;
    int WeakEnInt;
    int WeakEnAgi;

    int SlowEnAgi;
    //bool SlowEnAgiTrue = false;

    // Hold basic value when status effects active
    //int NoStatusEffect;
    int NoConfusionEffect;
    int ConfusionEffectCon;

    // Neutral status effects
    int NoStatusEffect; //DELETE

    int STRBuff, STRNerf, DEXBuff, DEXNerf, INTBuff, INTNerf; // Stats buff/nerf when attacking different Class foe

    int EnStrBuff, EnStrNerf, EnDexBuff, EnDexNerf, EnIntBuff, EnIntNerf; // Stats buff/nerf when attacking different Class foe


    // shows player and enemy damages calculated
    public Text DmgDoneTxt;
    public Text DmgTakenTxt;

    public bool DoubleDmg = false;
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

    //float EnemyDeathTime = 2.5f;

    public float SpawnPosX = 0;
    public float SpawnPosY = 0;

    // PLAYER STATUS EFFECTS HERE

    public int StunEffect = 0;
    public int PoisonEffect = 0;
    public int ConfusionEffect = 0;
    public int WeakenEffect = 0;
    public int SlowEffect = 0;
    public int BurnEffect = 0;


    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false; //Makes object invisible
        GetComponent<Animator>().enabled = false;

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
        PersistentManagerScript.Instance.EnLvl = EnLVL;

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
        GetComponent<SpriteRenderer>().enabled = true; //Makes object visible
        GetComponent<Animator>().enabled = true;
        GetPlayerStats();
        PersistentManagerScript.Instance.XPScreen = 0;
        transform.SetParent(myParentObject.transform);
        transform.position = new Vector2(SpawnPosX, SpawnPosY);
        PersistentManagerScript.Instance.FightScreen = true;
        DrawEnStatsOnce();
        StartCoroutine(FightStart());
    }

    void DrawEnStatsOnce()
    {

        EnDexTxt.text = EnDex.ToString();
        EnDexTxt.text = "Dex     " + EnDexTxt.text;

        EnIntTxt.text = EnCon.ToString();
        EnIntTxt.text = "Int       " + EnIntTxt.text;

        EnLVL = PersistentManagerScript.Instance.Lvl;

        EnLVLTxt.text = EnLVL.ToString();
        EnLVLTxt.text = ("Level ") + EnLVLTxt.text + (" (Rogue)");

    }


    void DrawEnStatsUpdate()
    {
        EnStrTxt.text = EnStr.ToString();
        EnStrTxt.text = "Str      " + EnStrTxt.text;

        EnConTxt.text = EnCon.ToString();
        EnConTxt.text = "Con     " + EnConTxt.text;

        EnAgiTxt.text = EnAgi.ToString();
        EnAgiTxt.text = "Agi      " + EnAgiTxt.text;

        EnHealthTxt.text = EnHealth.ToString();
        EnHealthTxt.text = "HP      " + EnHealthTxt.text;

        EnLVL = PersistentManagerScript.Instance.Lvl;

        PersistentManagerScript.Instance.EnemyHealth = EnHealth;
    }

    void PlayerDamageDone()
    {
        if (DoubleDmg == true)
        {
            DmgCalc -= EnHealth;

            DmgDoneTxt.text = DmgCalc.ToString();
            DmgDoneTxt.text = "2x";


        }
        else
        {
            DmgCalc -= EnHealth;

            DmgDoneTxt.text = DmgCalc.ToString();
            DmgDoneTxt.text = "-" + DmgDoneTxt.text;

        }
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



        DrawEnStatsUpdate();

        //BASIC ATTACK
        if (PersistentManagerScript.Instance.PlayerTurn == true && PersistentManagerScript.Instance.BasicAttack == true)
        {

            if (PersistentManagerScript.Instance.BasicAttack == true)
            {
                PersistentManagerScript.Instance.BasicAttack = false;
                //GetPlayerStats();
                //StartCoroutine(PlayerBasicAttack());

                if (AGI / 2 >= EnAgi)
                {

                    GetPlayerStats();
                    DoubleDmg = true;
                    PlayerDamageDone();
                    StartCoroutine(PlayerBasicAttack());

                    StartCoroutine(PlayerBasicAttack());

                    DoubleDmg = false;
                }
                else //if (AGI / 2 <= EnAgi)
                {
                    GetPlayerStats();
                    StartCoroutine(PlayerBasicAttack());
                }

                PersistentManagerScript.Instance.PlayerTurn = false;
            }
        }


        //SUPER ATTACK
        if (PersistentManagerScript.Instance.PlayerTurn == true && PersistentManagerScript.Instance.SuperAttack == true)
        {
            if (PersistentManagerScript.Instance.SuperAttack == true)
            {
                PersistentManagerScript.Instance.SuperAttack = false;
                GetPlayerStats();
                StartCoroutine(PlayerSuperAttack());

                PersistentManagerScript.Instance.PlayerTurn = false;
            }
        }

        //ULTRA ATTACK
        if (PersistentManagerScript.Instance.PlayerTurn == true && PersistentManagerScript.Instance.UltraAttack == true)
        {
            if (PersistentManagerScript.Instance.UltraAttack == true)
            {
                PersistentManagerScript.Instance.UltraAttack = false;
                GetPlayerStats();
                StartCoroutine(PlayerUltraAttack());

                PersistentManagerScript.Instance.PlayerTurn = false;
            }

        }

        //DEFENSE
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
        PersistentManagerScript.Instance.EnDies = 0;

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

        yield return new WaitForSeconds(0.5f);

        PersistentManagerScript.Instance.EnDies = 1;
        /*
        yield return new WaitForSeconds(EnemyDeathTime);

        PersistentManagerScript.Instance.XPScreen = 0;
        PersistentManagerScript.Instance.PlayerTurn = false;
        PersistentManagerScript.Instance.FightScreen = false;

        Destroy(gameObject);
        */
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

    IEnumerator PlayerUltraAttack() //CLASS1 STATS
    {
        if (EnHealth >= 0 && PersistentManagerScript.Instance.EnemyTurn == false)
        {
            PersistentManagerScript.Instance.StartRandomCrit = true;


            yield return new WaitForSeconds(TurnStartTime);



            if (PlayerClass == 1) // Ultra Attack from Class1 -> ///Cost-20 MP
            {

                CriticalHitClac();
                ClassBuffNerf();
                //ConfusionEffect += 1;
                if (WeakenEffect == 0)
                {
                    WeakenEffect += 4;
                }

                //NoConfusionEffect = STR;
                //STR = 20; // ATTACK   
                PersistentManagerScript.Instance.PlayerMana -= 20;

                if (STRNerf >= EnCon)
                {
                    DmgCalc = EnHealth;
                    EnHealth -= STRNerf - EnCon;

                    PlayerDamageDone();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgDoneTxt.text = " ";
                }
                else
                {


                }


                //STR = NoConfusionEffect; // ATTACK RESET VALUE                          

            }

            if (PlayerClass == 2) // 
            {
                if (SlowEffect == 0)
                {
                    SlowEffect += 4;
                    EnAgi -= 5;

                    SlowEnAgi = EnAgi;
                }
                PersistentManagerScript.Instance.PlayerMana -= 20;


                CriticalHitClac();
                ClassBuffNerf();



                if (DEX >= EnCon)
                {
                    var DexUltra = 5;


                    DmgCalc = EnHealth;
                    //EnHealth -= DEXNerf - EnCon;
                    EnHealth -= (DexUltra + DEX) - EnCon;
                    PlayerDamageDone();
                    yield return new WaitForSeconds(DmgCalcTime);
                    DmgDoneTxt.text = " ";

                }
                else
                {

                }


            }

            if (PlayerClass == 3) // Super Attack from Class3 -> makes 10dmg/confusion effect //Cost-10MP
            {
                CriticalHitClac();
                ClassBuffNerf();

                PersistentManagerScript.Instance.PlayerMana -= 10;
                if (BurnEffect == 0)
                {
                    BurnEffect += 4;
                }


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

                }


            }

            yield return new WaitForSeconds(TurnEndTime);
            {
                PersistentManagerScript.Instance.EnemyTurn = true;

            }
        }


    }


    IEnumerator PlayerSuperAttack() ///////////////////////////////////

    {

        if (EnHealth >= 0 && PersistentManagerScript.Instance.EnemyTurn == false)
        {
            PersistentManagerScript.Instance.StartRandomCrit = true;

            yield return new WaitForSeconds(TurnStartTime);



            if (PlayerClass == 1) // Super Attack from Class1 -> makes 15 dmg/ stuns opponent///Cost-15 MP
            {
                CriticalHitClac();
                ClassBuffNerf();

                StunEffect += 1;///Check made in EnemyBasicAttack if true
                NoStatusEffect = STR;
                STR = 15; // ATTACK
                PersistentManagerScript.Instance.PlayerMana -= 15;

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
                
                STR = NoStatusEffect; // ATTACK RESET VALUE

            }

            if (PlayerClass == 2) // Super Attack from Class2 -> makes 10 dmg/ poison damage ///Cost-10 MP
            {
                if (PoisonEffect == 0)
                {
                    PersistentManagerScript.Instance.PlayerMana -= 10;
                    PoisonEffect += 2;
                }
                else if (PoisonEffect == 1)
                {
                    PoisonEffect += 1;
                }

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

            if (PlayerClass == 3) // Super Attack from Class3 -> makes 10dmg/confusion effect //Cost-10MP
            {
                CriticalHitClac();
                ClassBuffNerf();

                PersistentManagerScript.Instance.PlayerMana -= 10;
                ConfusionEffect += 1;


                var confusion = EnCon - EnCon; // Enemy Con = 0


                if (INTNerf >= EnCon)
                {
                    DmgCalc = EnHealth;
                    EnHealth -= INTNerf - confusion;
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


    IEnumerator PlayerBasicAttack() // Defense added too
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




        if (StunEffect == 0) // CHECK CLASS1 SUPER ATTACK STATUS EFFECTS
        {


            if (EnHealth >= 0)
            {
                yield return new WaitForSeconds(TurnStartTime);

                ClassBuffNerf();

                if (WeakenEffect == 4)
                {
                    WeakEnStr = EnStr;
                    WeakEnDex = EnDex;
                    WeakEnInt = EnInt;



                    EnStr = EnStr - 4;
                    EnDex = EnDex - 4;
                    EnInt = EnInt - 4;
                    //WeakenEffect -= 1;


                }

                if (PoisonEffect >= 1)
                {
                    PoisonEffect -= 1;
                    PersistentManagerScript.Instance.PoisonActive = true;
                }
                else
                {
                    PersistentManagerScript.Instance.PoisonActive = false;
                }
                
                if (ConfusionEffect >= 1)
                {
                    ConfusionEffectCon = EnCon;
                    //NoStatusEffect = EnCon;
                    EnCon -= 5;
                    PersistentManagerScript.Instance.ConfusionActive = true;
                }

                if (SlowEffect >= 2)
                {


                    SlowEffect -= 1;
                    PersistentManagerScript.Instance.SlowActive = true;
                }


                if (BurnEffect >= 1)
                {
                    EnHealth -= 5;
                    BurnEffect -= 1;
                    PersistentManagerScript.Instance.BurnActive = true;
                }
                else
                {
                    PersistentManagerScript.Instance.BurnActive = false;
                }

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
                ///RETURN STATUS EFFECTS HERE ///////////
                if (ConfusionEffect >= 1)
                {
                    //ConfusionEffectCon = EnCon;
                    //NoStatusEffect = EnCon;
                    //EnCon -= 5;
                    ConfusionEffect -= 1;
                    EnCon = ConfusionEffectCon;
                }


                if (WeakenEffect >= 1)
                {
                    WeakenEffect -= 1;
                    PersistentManagerScript.Instance.WeakenActive = true;
                }

                if (WeakenEffect == 1)
                {
                    EnStr = WeakEnStr;
                    EnDex = WeakEnDex;
                    EnInt = WeakEnInt;
                    //EnAgi = WeakEnAgi;
                }

                if (SlowEffect == 1)
                {
                    EnAgi += 5;
                    SlowEffect = 0;
                    PersistentManagerScript.Instance.SlowActive = false;
                }
                // BurnEffect = No need stuff here
                // StunEffect = else command down below

            }

        }
        else //Return Stun status effect 
        {
            PersistentManagerScript.Instance.StunActive = true;
            StunEffect = 0;

        }

        if (PlayerDefUP == true)
        {
            EnStr = KeepEnStr;
            EnDex = KeepEnDex;
            EnInt = KeepEnInt;

            DmgCalc = EnHealth;

            if (PlayerClass == 1) // Player1 Defense skill counter attack 50%/STR
            {
                if ((STR / 2) >= EnCon)
                {


                    EnHealth -= (STR / 2) - EnCon;


            }

                PersistentManagerScript.Instance.PlayerHealth = PlayerHealth;
                DmgDoneTxt.text = " ";
                PlayerDamageDone();
                yield return new WaitForSeconds(DmgCalcTime);
                DmgDoneTxt.text = " ";


            }
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

