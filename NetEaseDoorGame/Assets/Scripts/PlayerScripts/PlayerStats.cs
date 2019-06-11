using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    Normal,
    Roll,
    Onhit,
    OpenDoor,
}



public class PlayerStats : Bolt.EntityEventListener<IPlayerState>
{
    //character state
    public PlayerState currState;

    public bool death = false;
    public float initialHealth;
    public float maxHealth;
    public float currentHealth;

    public float maxStamina = 100;
    public float currStamina;
    public float staminaRegen = 5;

    public float initialArmour = 0;
    public float currentArmour;
    public float maxArmour = 40;

    public float Speed = 6;
    SimpleHealthBar healthBar;
    SimpleHealthBar armourBar;
    SimpleHealthBar staminaBar;


    public float rolllasttime = 1f;
    public float rollcost = 30;
    

    Camera playercamera;
    public Camera playercameraprefab;
   
    public float projectileSpeed;
    public float projectileSize;
    public float dmg = 5;
    public string attackeffect = "none";
    public float attackcost = 10;
    public float firearate = 0.4f;
    public float existtime = 0.5f;

    public int money = 0;

    public bool immune = false;

    public override void Attached()

    {


        if (!entity.IsOwner) return;

        currentHealth = initialHealth;
        currentArmour = initialArmour;
        currStamina = maxStamina;
        state.Health = currentHealth;


        healthBar = GameObject.Find("Healthbar Fill 01").GetComponent<SimpleHealthBar>();
        if (healthBar != null) Debug.Log("healthbar found!");

        staminaBar = GameObject.Find("Staminabar Fill 01").GetComponent<SimpleHealthBar>();
        if (staminaBar != null) Debug.Log("staminabar found!");
        //currentArmour = initialArmour;
        /*armourBar = GameObject.Find("Armourbar Fill 01").GetComponent<SimpleArmourBar>();
        if (armourBar != null) Debug.Log("bar found!");*/


        


        playercamera = Instantiate(playercameraprefab, new Vector3(0, 15, 0), Quaternion.identity);
        
        playercamera.transform.LookAt(Vector3.zero);
        playercamera.GetComponent<CameraPosFollow>().GetPlayer(this.gameObject);

    }
    
    //Network Actions here
    public override void SimulateOwner()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
        staminaBar.UpdateBar(currStamina, maxStamina);
        //armourBar.UpdateBar(currentArmour, maxArmour);

        DeathDetection();
    }

    //Local Actions here
    public void Update()
    {
        StaminaRegen();
    }
    void StaminaRegen() {

        if (currStamina < 0) currStamina = 0;
        if (currStamina > maxStamina) currStamina = maxStamina;


      
        if (currStamina < maxStamina) {
            currStamina += staminaRegen * Time.deltaTime;
        }
    }

    public void DeathDetection()
    {
        if (currentHealth <= 0)
        {
            death = true;
        }
    }


    public void Hitreaction(float dmg, string effect ) {
        Debug.Log("Hit");

        if (immune) return;

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


