using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    bool death = false;
    [SerializeField]
    float health;
    [SerializeField]
   public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<CharacterMovement>().speed = this.speed;
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
