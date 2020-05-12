using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaController : MonoBehaviour
{
    //public static HealthController Instance { get; set; }   // Testing if works better as Singleton

    public int maxMana;
    public int currentMana;

    public HealthBarScript healthBar;



    // Start is called before the first frame update
    void Start()
    {
        //maxMana = PersistentManagerScript.Instance.PlayerMana;

        PersistentManagerScript.Instance.PlayerMana = PersistentManagerScript.Instance.maxMana;

        maxMana = PersistentManagerScript.Instance.maxMana;

        currentMana = maxMana;
        healthBar.SetMaxHealth(maxMana);

    }

    void Update()
    {
        maxMana = PersistentManagerScript.Instance.maxMana;

        currentMana = PersistentManagerScript.Instance.PlayerMana;
        healthBar.SetHealth(currentMana);

        if (currentMana <= 0)
        {
            Debug.Log("Mana empty");

        }


    }




}
