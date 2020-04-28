using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManagerScript : MonoBehaviour
{
    public GameObject World1;
    public GameObject TamaMenu;




    public void GoToWorld1()
    {
        World1.SetActive(true);
        TamaMenu.SetActive(false);
        //SceneManager.LoadScene("TamaMenuScene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToTamaMenu()
    {
        
        TamaMenu.SetActive(true);
        World1.SetActive(false);

        //SceneManager.LoadScene("World1Scene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
}
