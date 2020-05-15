using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{
    public GameObject ParticleEffects;
    public GameObject BurnAttack;
    public GameObject BurnStay;
    public GameObject PoisonAttack;
    public GameObject SlowStay;

    public GameObject GetHP;

    void Start()
    {
        //BurnAttack.GetComponent<ParticleSystem>().Stop();
        //PoisonAttack.GetComponent<ParticleSystem>().Stop();


    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.FightScreen == true)
        {
            ParticleEffects.SetActive(true);
        }
        else
        {
            ParticleEffects.SetActive(false);
        }

        if (PersistentManagerScript.Instance.UltraAttack == true && PersistentManagerScript.Instance.PlayerClass == 3)
        {
            BurnAttack.GetComponent<ParticleSystem>().Play();
        }

        if (PersistentManagerScript.Instance.PoisonActive == false) // Dunno why this works on false???
        {

            PoisonAttack.GetComponent<ParticleSystem>().Play();
        }

        if (PersistentManagerScript.Instance.BurnActive == false) // Dunno why this works on false???
        {

            BurnStay.GetComponent<ParticleSystem>().Play();
        }

        if (PersistentManagerScript.Instance.UltraAttack == true && PersistentManagerScript.Instance.PlayerClass == 2)
        {
            SlowStay.GetComponent<ParticleSystem>().Play();
        }

        if (Input.GetKeyDown("f"))
        BurnAttack.GetComponent<ParticleSystem>().Play();

    }

    public void GetHPTamaScreen()
    {
        GetHP.GetComponent<ParticleSystem>().Play();
        PersistentManagerScript.Instance.PlayerHealth = 100;
    }


}
