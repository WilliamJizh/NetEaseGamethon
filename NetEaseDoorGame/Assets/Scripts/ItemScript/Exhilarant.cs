using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhilarant : ItemClass
{

    public GameObject player;
   
    private PlayerStats playerStats;

 

    void Awake()
    {
        


    }
    // Start is called before the first frame update
    void Start()
    {
    	names = "Stimulant";
        discription = "Increase attack speed";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {

            setPlayer();
            IncreaseFireRate();
            collected = false;
        }
    }

    void IncreaseFireRate()
    {
        //the variable firearate is actually the pause time between two fires. 
        //So the smaller the firearate is (0.8 times the original firerate), the faster the fire goes.
      
        playerStats.firearate *= 0.8f;
    }

    void setPlayer()
    {
        player = getPlayer();
        
        playerStats = player.GetComponent<PlayerStats>();

    }

    
}
