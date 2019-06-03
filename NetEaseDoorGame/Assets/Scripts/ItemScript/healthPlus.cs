using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPlus : MonoBehaviour
{
   

    PlayerStats playerstat;

    // Start is called before the first frame update
    void Start()
    {
        playerstat = GetComponent<PlayerStats>();
       

    }

    // Update is called once per frame
    void Update()
    {

    }
   
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("AddHealth"))
        {
            playerstat.currentHealth += 20;
            if(playerstat.currentHealth >= playerstat.maxHealth)
            {
                playerstat.currentHealth = playerstat.maxHealth;
            }
          

         Destroy(col.gameObject);

        }
    }

}
