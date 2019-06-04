using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Bolt.EntityEventListener<IPlayerState>
{
    public bool death = false;
    public float initialHealth;
    public float maxHealth;
    public float currentHealth;
    
    public float speed = 6;
    public SimpleHealthBar healthBar;
    public SimpleArmourBar armourBar;
    public float dmg = 5;
    public string attackeffect = "none";
    
    public float initialArmour = 0;
    public float currentArmour;
    public float maxArmour = 40;


    public override void Attached()
    {
        currentHealth = initialHealth;
        currentArmour = initialArmour;
        
        healthBar = GameObject.Find("Healthbar Fill 01").GetComponent<SimpleHealthBar>();
        if (healthBar != null) Debug.Log("bar found!");
        
        armourBar = GameObject.Find("Armourbar Fill 01").GetComponent<SimpleArmourBar>();
        if (armourBar != null) Debug.Log("bar found!");
    }
    

    public override void SimulateOwner()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
        armourBar.UpdateBar(currentArmour, maxArmour);
        
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
        if(currentArmour == 0){
        currentHealth -= dmg;
        }
        
        else if(currentArmour < dmg){
        currentArmour = 0;
        currentHealth -= (dmg - currentArmour);
        }
        
        else if(currentArmour >= dmg){
        currentArmour -= dmg;
        }
    }

}


