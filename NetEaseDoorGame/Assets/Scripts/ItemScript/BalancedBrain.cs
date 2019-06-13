using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancedBrain : ItemClass
{


    public GameObject Player;
    private PlayerStats playerstat;
    private ItemMananger itemManager;



    // Start is called before the first frame update
    void Start()
    {
        names = "Magic Fish";
        discription = "Increased size of attack, slowed attack speed";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
           
            setPlayer();
            playerstat.projectileSize *= 1.25f;
            playerstat.firearate *= 1.15f;
            
             collected =false;
        }
    }

    void setPlayer()
    {
        Player = getPlayer();
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();


    }
}
