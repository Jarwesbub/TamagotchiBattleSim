using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        TakeDamage(20);


        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            GetHP(20);

    }

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


}
