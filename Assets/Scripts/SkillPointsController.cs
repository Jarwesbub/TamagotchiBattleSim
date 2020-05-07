using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointsController : MonoBehaviour
{
    public int SkillPoints;
    public Text SkillPointsTxt;


    public void Start()
    {
        SkillPoints = PersistentManagerScript.Instance.SkillPoints;
     }

    public void Update()
    {
        

        if (PersistentManagerScript.Instance.Lvl == 1)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();
            SkillPoints = 0;


        }

        if (PersistentManagerScript.Instance.Lvl == 2)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 2;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 3)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 2;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 4)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 3;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 5)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 3;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 6)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 4;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 7)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 4;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 8)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 4;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 9)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 5;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

        if (PersistentManagerScript.Instance.Lvl == 10)
        {
            SkillPointsTxt.text = ("Skill Points: ") + SkillPoints.ToString();

            if (PersistentManagerScript.Instance.LvlGet == true)
            {
                SkillPoints += 5;
                PersistentManagerScript.Instance.LvlGet = false;
            }

        }

    }



    public void StrAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Str += 1;
            SkillPoints -= 1;
        }

    }

    public void ConAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Con += 1;
            SkillPoints -= 1;
        }

    }

    public void DexAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Dex += 1;
            SkillPoints -= 1;
        }

    }

    public void AgiAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Agi += 1;
            SkillPoints -= 1;
        }

    }

    public void IntAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Int += 1;
            SkillPoints -= 1;
        }

    }

    public void LuckAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Luck += 1;
            SkillPoints -= 1;
        }

    }

    public void WisAdd()
    {
        if (SkillPoints >= 1) //if there is more than 0 skill points available
        {
            PersistentManagerScript.Instance.Wis += 1;
            SkillPoints -= 1;
        }

    }

    /*
    PersistentManagerScript.Instance.Str = 10;
    PersistentManagerScript.Instance.Con = 9;
    PersistentManagerScript.Instance.Dex = 8;
    PersistentManagerScript.Instance.Agi = 9;
    PersistentManagerScript.Instance.Int = 13;
    PersistentManagerScript.Instance.Luck = 10;
    */



}
