using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Bolt.EntityBehaviour
{
    public bool death = false;
    public float initialHealth = 100;
    public float maxHealth;
    public float currentHealth;
    public float speed = 6;
    public SimpleHealthBar healthBar;


    public override void Attached()
    {
        currentHealth = initialHealth;
        maxHealth = initialHealth;
        healthBar = GameObject.Find("Healthbar Fill 01").GetComponent<SimpleHealthBar>();
        if (healthBar != null) Debug.Log("bar found!");
    }

    public override void SimulateOwner()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
        DeathDetection();
    }


    public void DeathDetection()
    {
        if (currentHealth <= 0)
        {
            death = true;
        }
    }


}


