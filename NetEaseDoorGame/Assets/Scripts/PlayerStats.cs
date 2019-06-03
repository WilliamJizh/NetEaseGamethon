using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Bolt.EntityEventListener<IPlayerState>
{
    public bool death = false;
    public float initialHealth = 100;
    public float maxHealth;
    public float currentHealth;
    public float speed = 6;
    public SimpleHealthBar healthBar;
    public float dmg = 5;
    public string attackeffect = "none";
    public Camera playercamera;

    public override void Attached()
    {
        currentHealth = initialHealth;
        maxHealth = initialHealth;
        state.Health = currentHealth;
        healthBar = GameObject.Find("Healthbar Fill 01").GetComponent<SimpleHealthBar>();
        if (healthBar != null) Debug.Log("bar found!");

        playercamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playercamera.GetComponent<CameraPosFollow>().GetPlayer(this.gameObject);
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


    public void Hitreaction(float dmg, string effect) {
        Debug.Log("Hit");
        currentHealth -= dmg;
    }

}


