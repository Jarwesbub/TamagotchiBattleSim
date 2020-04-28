using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    // Attacking stats

    public Text StrTxt; //Strength based attacks
    public Text DexTxt; //Dexterity based attacks
    public Text AgiTxt; //Agility based attacks
    public Text IntTxt; //Intelligence based attacks

    // Basic stats

    public Text ConTxt; //Health and resistance chance
    public Text LuckTxt; //Critical hit chance


    private void Start()
    {
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

    }

    public void GoToTamaMenuScene()
    {
        SceneManager.LoadScene("TamaMenuScene");
        PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToWorld1Scene()
    {
        SceneManager.LoadScene("World1Scene");
        PersistentManagerScript.Instance.Str++; //test add 1

    }
}
