using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClassSelect : MonoBehaviour
{
    public void GoClassSelectScene()
    {
        SceneManager.LoadScene("ClassSelectScene");

    }



    public void ChooseClass1()
    {
        PersistentManagerScript.Instance.PlayerClass = 1;
        SceneManager.LoadScene("World1Scene");
    }

    public void ChooseClass2()
    {
        PersistentManagerScript.Instance.PlayerClass = 2;
        SceneManager.LoadScene("World1Scene");
    }

    public void ChooseClass3()
    {
        PersistentManagerScript.Instance.PlayerClass = 3;
        SceneManager.LoadScene("World1Scene");
    }
}
