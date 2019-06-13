using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkNBread : ItemClass
{
    public GameObject player;
    private PlayerStats playerStats;

    void Awake()
    {

        //temp implementation (player should get from collision)
      
       
    }
    // Start is called before the first frame update
    void Start()
    {
        names = "Milk bread";
        discription = "Increase maximum health";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        //if player uses the item, increase initial health.
        // NOTE: NEED TO CLEAR THE ITEM LIST AFTER PLAYER USED IT.
        if (collected)
        {
            setPlayer();
            playerStats.maxHealth += 15;
            Debug.Log("Used Milk and Bread! Your max health increased by 15.");
            collected = false;
            
        }
    }
    void setPlayer()
    {
        player = getPlayer();

        playerStats = player.GetComponent<PlayerStats>();
        
    }
}
