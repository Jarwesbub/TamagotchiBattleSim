using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManagerScript : MonoBehaviour
{
    public GameObject World1;
    public GameObject OpenWorld;
    public GameObject TamaMenu;
    public GameObject SkillPointsMenu;
    public GameObject CanvasStats;
    public GameObject FightScreen;
    public GameObject CanvasFight;
    public GameObject MainCamera; // When moving to gameplay screen -> disable "Statscamera"

    public GameObject PlayerMove;
    public GameObject PlayerFight;

    public GameObject GoMenu;

    public void GoToWorld1()
    {
        World1.SetActive(true);
        OpenWorld.SetActive(true);
        TamaMenu.SetActive(false);
        SkillPointsMenu.SetActive(false);
        MainCamera.SetActive(false);
        CanvasStats.SetActive(false);

        PlayerMove.SetActive(true);
        PlayerFight.SetActive(false);

        //SceneManager.LoadScene("TamaMenuScene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToTamaMenu()
    {
        
        TamaMenu.SetActive(true);
        World1.SetActive(false);
        OpenWorld.SetActive(false);
        SkillPointsMenu.SetActive(false);
        MainCamera.SetActive(true);
        CanvasStats.SetActive(true);

        //SceneManager.LoadScene("World1Scene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToSkillPoints()
    {

            SkillPointsMenu.SetActive(true);
            World1.SetActive(false);
            OpenWorld.SetActive(false);
            TamaMenu.SetActive(false);
            MainCamera.SetActive(true);
            CanvasStats.SetActive(true);

    }



    public void AddLevel()
    {
        PersistentManagerScript.Instance.LvlGet = true;
        PersistentManagerScript.Instance.Lvl += 1;
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            PersistentManagerScript.Instance.FightScreen = false;

        }



        if (PersistentManagerScript.Instance.FightScreen == true)
        {
            World1.SetActive(true);
            OpenWorld.SetActive(false);
            TamaMenu.SetActive(false);
            SkillPointsMenu.SetActive(false);
            CanvasStats.SetActive(false);
            PlayerMove.SetActive(false);
            PlayerFight.SetActive(true);
            GoMenu.SetActive(false);

            MainCamera.SetActive(true);
            FightScreen.SetActive(true);
            CanvasFight.SetActive(true);
        }
        
        else
        {
            GoMenu.SetActive(true);
            OpenWorld.SetActive(true);
            PlayerMove.SetActive(true);
            PlayerFight.SetActive(false);
            CanvasFight.SetActive(false);
        }
        
    }

}
