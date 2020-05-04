using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightControl : MonoBehaviour
{
    
    bool FightWait = false;

    
    float FightWaitTime = 2f;
    float FightTimer;

    public void MakeBasicAttack()
    {
        if (FightWait == false && PersistentManagerScript.Instance.PlayerTurn == true)
        {
            PersistentManagerScript.Instance.PlayerTurn = true;
            PersistentManagerScript.Instance.BasicAttack = true;

            FightWait = true;

            StartCoroutine(FightWaitButtonPress());
        }
        
        



    }

    public void MakeBasicDefense()
    {
        /*
        if (PersistentManagerScript.Instance.BasicDefense == false)
        {
            PersistentManagerScript.Instance.PlayerTurn = false;
            PersistentManagerScript.Instance.BasicDefense = true;
        }
        */

        if (FightWait == false && PersistentManagerScript.Instance.PlayerTurn == true)
        {
            PersistentManagerScript.Instance.PlayerTurn = true;
            PersistentManagerScript.Instance.BasicDefense = true;

            FightWait = true;

            StartCoroutine(FightWaitButtonPress());
        }





    }
    
    IEnumerator FightWaitButtonPress()
    {
        FightTimer = FightWaitTime;
        yield return new WaitForSeconds(FightTimer);
        FightWait = false;
    }
    


}
