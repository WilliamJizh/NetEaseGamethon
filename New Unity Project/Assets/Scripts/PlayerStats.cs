using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    bool death = false;
    float health;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 6;
        GetComponent<CharacterMovement>().speed=this.speed;
        DeathDetection();
    }

    public void DeathDetection()
    {
        if (health <= 0)
        {
            death = true;
        }
    }
}
