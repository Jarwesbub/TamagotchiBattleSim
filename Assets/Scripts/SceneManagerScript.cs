using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public Text StrTxt;
    public Text AgiTxt;
    public Text IntTxt;


    private void Start()
    {
        StrTxt.text = PersistentManagerScript.Instance.Str.ToString();
        StrTxt.text = "Str  " + StrTxt.text;

        AgiTxt.text = PersistentManagerScript.Instance.Agi.ToString();
        AgiTxt.text = "Agi  " + AgiTxt.text;

        IntTxt.text = PersistentManagerScript.Instance.Int.ToString();
        IntTxt.text = "Int  " + IntTxt.text;

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
