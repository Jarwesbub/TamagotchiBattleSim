using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffects : MonoBehaviour
{
    public GameObject StunEff;
    public GameObject PoisonEff;
    public GameObject ConfEff;
    public GameObject WeakenEff;
    public GameObject SlowEff;
    public GameObject BurnEff;

    public Text StunTxt;
    public Text PoisonTxt;
    public Text ConfTxt;
    public Text WeakenTxt;
    public Text SlowTxt;
    public Text BurnTxt;

    float WaitTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(WaitTime);

        PersistentManagerScript.Instance.StunActive = false;
        //PersistentManagerScript.Instance.PoisonActive = false;
        PersistentManagerScript.Instance.ConfusionActive = false;
        //PersistentManagerScript.Instance.WeakenActive = false;
        //PersistentManagerScript.Instance.SlowActive = false;
        //PersistentManagerScript.Instance.BurnActive = false;

    }



    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.XPScreen == 1)
        {
            PersistentManagerScript.Instance.StunActive = false;
            PersistentManagerScript.Instance.PoisonActive = false;
            PersistentManagerScript.Instance.ConfusionActive = false;
            PersistentManagerScript.Instance.WeakenActive = false;
            PersistentManagerScript.Instance.SlowActive = false;
            PersistentManagerScript.Instance.BurnActive = false;





        }



        if (PersistentManagerScript.Instance.StunActive == true)
        {
            StunEff.SetActive(true);
            StartCoroutine(Wait());
            
        }
        else
        {
            StunEff.SetActive(false);
        }

        if (PersistentManagerScript.Instance.PoisonActive == true)
        {
            PoisonEff.SetActive(true);
            //StartCoroutine(Wait());

        }
        else
        {
            PoisonEff.SetActive(false);
        }

        if (PersistentManagerScript.Instance.ConfusionActive == true)
        {
            ConfEff.SetActive(true);
            
            StartCoroutine(Wait());

        }
        else
        {
            ConfEff.SetActive(false);
        }

        if (PersistentManagerScript.Instance.WeakenActive == true)
        {
            WeakenEff.SetActive(true);
            //StartCoroutine(Wait());

        }
        else
        {
            WeakenEff.SetActive(false);
        }

        if (PersistentManagerScript.Instance.SlowActive == true)
        {
            SlowEff.SetActive(true);
            //StartCoroutine(Wait());

        }
        else
        {
            SlowEff.SetActive(false);
        }

        if (PersistentManagerScript.Instance.BurnActive == true)
        {
            BurnEff.SetActive(true);
            //StartCoroutine(Wait());

        }
        else
        {
            BurnEff.SetActive(false);
        }
    }
}
