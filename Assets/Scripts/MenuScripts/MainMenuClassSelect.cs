using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClassSelect : MonoBehaviour
{
    public GameObject ContinueButton;


    void Start()
    {
        ContinueButton.SetActive(false);

        if (PersistentManagerScript.Instance.PlayerHealth <= 1)
        {
            ContinueButton.SetActive(true);
        }

    }

    public void GoClassSelectScene()
    {
        //PersistentManagerScript.Instance.PlayerHealth = 100;
        SceneManager.LoadScene("ClassSelectScene");
        
    }

    public void ContinueGame()
    {
        PersistentManagerScript.Instance.PlayerHealth = 100;
        SceneManager.LoadScene("World1Scene");

    }


    public void ChooseClass1()
    {
        PersistentManagerScript.Instance.PlayerHealth = 100;
        PersistentManagerScript.Instance.Lvl = 1;
        PersistentManagerScript.Instance.PlayerClass = 1;
        SceneManager.LoadScene("World1Scene");
    }

    public void ChooseClass2()
    {
        PersistentManagerScript.Instance.PlayerHealth = 100;
        PersistentManagerScript.Instance.Lvl = 1;
        PersistentManagerScript.Instance.PlayerClass = 2;
        SceneManager.LoadScene("World1Scene");
    }

    public void ChooseClass3()
    {
        PersistentManagerScript.Instance.PlayerHealth = 100;
        PersistentManagerScript.Instance.Lvl = 1;
        PersistentManagerScript.Instance.PlayerClass = 3;
        SceneManager.LoadScene("World1Scene");
    }




}
