using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnHealthController : MonoBehaviour
{
    //public static HealthController Instance { get; set; }   // Testing if works better as Singleton

    public int maxHealth;
    public int currentHealth;

    public HealthBarScript healthBar;



    // Start is called before the first frame update
    void LateStart()
    {

        PersistentManagerScript.Instance.EnemyMaxHealth = PersistentManagerScript.Instance.EnemyHealth;

        maxHealth = PersistentManagerScript.Instance.EnemyMaxHealth;
        //currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        currentHealth = PersistentManagerScript.Instance.EnemyHealth;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {

        }

    }


}
