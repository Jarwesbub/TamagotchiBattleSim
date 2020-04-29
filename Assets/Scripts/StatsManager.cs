using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Text LvlTxt; //Player's current Level

    // Attacking stats

    public Text StrTxt; //Strength based attacks
    public Text DexTxt; //Dexterity based attacks
    public Text AgiTxt; //Agility based attacks
    public Text IntTxt; //Intelligence based attacks

    // Basic stats

    public Text ConTxt; //Health and resistance chance
    public Text LuckTxt; //Critical hit chance

    public Text PlayerClass;

    public GameObject PSClass1;
    public GameObject PSClass2;
    public GameObject PSClass3;

    public GameObject PlayerClass1;
    public GameObject PlayerClass2;
    public GameObject PlayerClass3;

    public GameObject TamaClass1;
    public GameObject TamaClass2;
    public GameObject TamaClass3;


    private void Update()
    {
        LvlTxt.text = PersistentManagerScript.Instance.Lvl.ToString();
        LvlTxt.text = "Level    " + LvlTxt.text;


        StrTxt.text = PersistentManagerScript.Instance.Str.ToString();
        StrTxt.text = "Str       " + StrTxt.text;

        DexTxt.text = PersistentManagerScript.Instance.Dex.ToString();
        DexTxt.text = "Dex      " + DexTxt.text;

        AgiTxt.text = PersistentManagerScript.Instance.Agi.ToString();
        AgiTxt.text = "Agi       " + AgiTxt.text;

        IntTxt.text = PersistentManagerScript.Instance.Int.ToString();
        IntTxt.text = "Int        " + IntTxt.text;

        ConTxt.text = PersistentManagerScript.Instance.Con.ToString();
        ConTxt.text = "Con      " + ConTxt.text;

        LuckTxt.text = PersistentManagerScript.Instance.Luck.ToString();
        LuckTxt.text = "Luck     " + LuckTxt.text;


        PlayerClass.text = PersistentManagerScript.Instance.PlayerClass.ToString();
        PlayerClass.text = "PlayerClass     " + PlayerClass.text;



        if (PersistentManagerScript.Instance.PlayerClass == 1)
        {
            PSClass1.SetActive(true);
            PlayerClass1.SetActive(true);
            TamaClass1.SetActive(true);
            
        }
        else
        {
            PSClass1.SetActive(false);
            PlayerClass1.SetActive(false);
            TamaClass1.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PlayerClass == 2)
        {
            PSClass2.SetActive(true);
            PlayerClass2.SetActive(true);
            TamaClass2.SetActive(true);
        }
        else
        {
            PSClass2.SetActive(false);
            PlayerClass2.SetActive(false);
            TamaClass2.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PlayerClass == 3)
        {
            PSClass3.SetActive(true);
            PlayerClass3.SetActive(true);
            TamaClass3.SetActive(true);
        }
        else
        {
            PSClass3.SetActive(false);
            PlayerClass3.SetActive(false);
            TamaClass3.SetActive(false);
        }




    }




}
