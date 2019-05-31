using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool death = false;
    public float initialHealth;
    public float maxHealth;
    public float currentHealth;
    public float speed;

   
    // Start is called before the first frame update
    void Start()
    {
       initialHealth = 100;

    }

    // Update is called once per frame
    void Update()
    {
        speed = 6;
        GetComponent<CharacterMovement>().speed = this.speed;
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


