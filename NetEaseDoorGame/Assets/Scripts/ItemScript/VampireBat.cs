using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireBat : ItemClass
{
    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats pstats;

    public float diffHealth;
    public float blood;
    float CountDownTimer;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        names = "Vampire Bat";
        discription = "The damage you dual will heal you";
        SetIcon();
        Collect();
       
    }

    // Update is called once per frame
    void Update()
    {
    	if(collected){
    	   setPlayer();

            blood = 0.4f * pstats.dmg;
    	   		
    	   		if(pstats.successfulhit == true){

                pstats.currentHealth += blood;
                pstats.successfulhit = false;
					
					}
    			
    	
    	}
        
    }
        void setPlayer()
    {
        player = getPlayer();
        pstats = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
    }
}
