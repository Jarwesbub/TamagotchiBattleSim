using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FightControl : MonoBehaviour
{
    
    bool FightWait = false;

    
    float FightWaitTime = 2f;
    float FightTimer;

    public Text Attack1Txt;
    public Text Attack2Txt;
    public Text Attack3Txt;
    public Text DefenseTxt;


    public void Update()
    {
        if (PersistentManagerScript.Instance.FightScreen == true)
        {
            if (PersistentManagerScript.Instance.PlayerClass == 1)
            {

                Attack1Txt.text = "Cleaving Strike";
                Attack2Txt.text = "Crushing Blow";
                Attack3Txt.text = "Total Brawl";
                DefenseTxt.text = "Steel Up";
            }

            if (PersistentManagerScript.Instance.PlayerClass == 2)
            {

                Attack1Txt.text = "Sneaky Attack";
                Attack2Txt.text = "Poison Attack";
                Attack3Txt.text = "Swarm of Caltrops";
                DefenseTxt.text = "Defense";
            }

            if (PersistentManagerScript.Instance.PlayerClass == 3)
            {

                Attack1Txt.text = "Magic Missle";
                Attack2Txt.text = "Brainstorm";
                Attack3Txt.text = "Fireball";
                DefenseTxt.text = "Arcane Protection";
            }


        }
    }



    public void MakeBasicAttack()
    {
        if (FightWait == false && PersistentManagerScript.Instance.PlayerTurn == true)
        {
            PersistentManagerScript.Instance.PlayerTurn = true;
            PersistentManagerScript.Instance.BasicAttack = true;

            FightWait = true;

            StartCoroutine(FightWaitButtonPress());
        }

    }

    public void MakeSuperAttack() //NEW
    {
        if (FightWait == false && PersistentManagerScript.Instance.PlayerTurn == true)
        {
            if (PersistentManagerScript.Instance.PlayerClass == 1 && PersistentManagerScript.Instance.PlayerMana >= 15)
            {
                PersistentManagerScript.Instance.PlayerTurn = true;
                PersistentManagerScript.Instance.SuperAttack = true;

                FightWait = true;

                StartCoroutine(FightWaitButtonPress());
            }

            if (PersistentManagerScript.Instance.PlayerClass == 2 && PersistentManagerScript.Instance.PlayerMana >= 10)
            {
                PersistentManagerScript.Instance.PlayerTurn = true;
                PersistentManagerScript.Instance.SuperAttack = true;

                FightWait = true;

                StartCoroutine(FightWaitButtonPress());
            }

            if (PersistentManagerScript.Instance.PlayerClass == 3 && PersistentManagerScript.Instance.PlayerMana >= 10)
            {
                PersistentManagerScript.Instance.PlayerTurn = true;
                PersistentManagerScript.Instance.SuperAttack = true;

                FightWait = true;

                StartCoroutine(FightWaitButtonPress());
            }
        }

    }

    public void MakeUltrattack() //NEW
    {
        if (FightWait == false && PersistentManagerScript.Instance.PlayerTurn == true)
        {
            if (PersistentManagerScript.Instance.PlayerClass == 1 && PersistentManagerScript.Instance.PlayerMana >= 20)
            {
                PersistentManagerScript.Instance.PlayerTurn = true;
                PersistentManagerScript.Instance.UltraAttack = true;

                FightWait = true;

                StartCoroutine(FightWaitButtonPress());
            }

            if (PersistentManagerScript.Instance.PlayerClass == 2 && PersistentManagerScript.Instance.PlayerMana >= 20)
            {
                PersistentManagerScript.Instance.PlayerTurn = true;
                PersistentManagerScript.Instance.UltraAttack = true;

                FightWait = true;

                StartCoroutine(FightWaitButtonPress());
            }

            if (PersistentManagerScript.Instance.PlayerClass == 3 && PersistentManagerScript.Instance.PlayerMana >= 20)
            {
                PersistentManagerScript.Instance.PlayerTurn = true;
                PersistentManagerScript.Instance.UltraAttack = true;

                FightWait = true;

                StartCoroutine(FightWaitButtonPress());
            }
        }

    }


    public void MakeBasicDefense()
    {
        /*
        if (PersistentManagerScript.Instance.BasicDefense == false)
        {
            PersistentManagerScript.Instance.PlayerTurn = false;
            PersistentManagerScript.Instance.BasicDefense = true;
        }
        */

        if (FightWait == false && PersistentManagerScript.Instance.PlayerTurn == true)
        {
            PersistentManagerScript.Instance.PlayerTurn = true;
            PersistentManagerScript.Instance.BasicDefense = true;

            FightWait = true;

            
            StartCoroutine(FightWaitButtonPress());
        }

    }
    
    IEnumerator FightWaitButtonPress()
    {
        FightTimer = FightWaitTime;
        yield return new WaitForSeconds(FightTimer);
        FightWait = false;
    }
    



}
