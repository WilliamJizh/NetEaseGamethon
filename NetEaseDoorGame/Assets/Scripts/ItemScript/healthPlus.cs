using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPlus : ItemClass
{

    public GameObject Player;
    private PlayerStats playerstat;
    private ItemMananger itemManager;

    // Start is called before the first frame update
    void Start()
    {
        playerstat = GetComponent<PlayerStats>();
        collected = false;

        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
            setPlayer();
            playerstat.currentHealth += 20;
            if (playerstat.currentHealth >= playerstat.maxHealth)
            {
                playerstat.currentHealth = playerstat.maxHealth;
            }

            collected = false;
        }
    }
   
   
   

    void setPlayer()
    {
        Player = getPlayer();
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();
    }


}
