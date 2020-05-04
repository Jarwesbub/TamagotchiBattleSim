using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    //public static HealthController Instance { get; set; }   // Testing if works better as Singleton

    public int maxHealth;
    public int currentHealth;

    public HealthBarScript healthBar;

    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = PersistentManagerScript.Instance.PlayerHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        currentHealth = PersistentManagerScript.Instance.PlayerHealth;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //PersistentManagerScript.Instance.GameReset = true;
            PersistentManagerScript.Instance.FightScreen = false;
            SceneManager.LoadScene("GameoverScene");

        }


        /*
        // Turhia juttuja alhaallas
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {

            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
            GetHP(20);
            */
    }

    /*

    public void GetHP()
    {
        GetHP(20);
    }

    void GetHP(int HP)
    {
        currentHealth += HP;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage()
    {
        TakeDamage(20);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    */

}
