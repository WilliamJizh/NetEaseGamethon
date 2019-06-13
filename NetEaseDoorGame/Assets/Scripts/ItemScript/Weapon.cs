using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemClass
{
    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats pstats;
    public float power;


    // Start is called before the first frame update
    void Start()
    {
        names = "青龙偃月刀";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
    	  
    	  
        if (collected)
        {
        
        	setPlayer();
        	

            IncreaseHealth();

            collected = false;
            
        }
    }
    void IncreaseHealth()
    {
        //increase player's dmg by 1.5
			pstats.dmg *= 1.15f;
    }

    void setPlayer()
    {
        player = getPlayer();
        pstats = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
    }
}