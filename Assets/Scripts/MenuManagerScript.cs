using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManagerScript : MonoBehaviour
{
    public GameObject World1;
    public GameObject TamaMenu;
    public GameObject SkillPointsMenu;

    public GameObject MainCamera; // When moving to gameplay screen -> disable "Statscamera"



    public void GoToWorld1()
    {
        World1.SetActive(true);
        TamaMenu.SetActive(false);
        SkillPointsMenu.SetActive(false);
        MainCamera.SetActive(false);
        //SceneManager.LoadScene("TamaMenuScene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToTamaMenu()
    {
        
        TamaMenu.SetActive(true);
        World1.SetActive(false);
        SkillPointsMenu.SetActive(false);
        MainCamera.SetActive(true);

        //SceneManager.LoadScene("World1Scene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToSkillPoints()
    {

            SkillPointsMenu.SetActive(true);
            World1.SetActive(false);
            TamaMenu.SetActive(false);
            MainCamera.SetActive(true);

    }



    public void AddLevel()
    {
        PersistentManagerScript.Instance.LvlGet = true;
        PersistentManagerScript.Instance.Lvl += 1;
    }


}
