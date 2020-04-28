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

    public GameObject Class1;
    public GameObject Class2;
    public GameObject Class3;

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
            Class1.SetActive(true);
        }
        else
        {
            Class1.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PlayerClass == 2)
        {
            Class2.SetActive(true);
        }
        else
        {
            Class2.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PlayerClass == 3)
        {
            Class3.SetActive(true);
        }
        else
        {
            Class3.SetActive(false);
        }




    }




}
