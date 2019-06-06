using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireBat : ItemClass
{
    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats pstats;
    private Projectile others;
    public float diffHealth;
    public float blood;
    float CountDownTimer;
    
    void Awake()
    {
    	  pstats = GetComponent<PlayerStats>();

        others = GetComponent<Projectile>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        names = "吸血蝙蝠";
        SetIcon();
        Collect();
        CountDownTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
    	while(collected){
    	   setPlayer();
    	   CountDownTimer -= Time.deltaTime;
    	   if(CountDownTimer>0f && CountDownTimer< 10f){
    	   		
    	   		diffHealth = pstats.maxHealth - pstats.currentHealth;
    	   		blood = 0.4f*others.targetstat.dmg;
    	   		CountDownTimer -= Time.deltaTime;
    	   		
    	   		if(others.successfulhit){
					
					if(diffHealth>0 && diffHealth<=blood){
						pstats.currentHealth = pstats.maxHealth;
						}
					else if(diffHealth>0 && diffHealth>blood){
						pstats.currentHealth += (blood+5*Time.deltaTime);
						}
					
					
					}
			else if(CountDownTimer<=0f){
				collected = false;
				blood = 0;
				CountDownTimer = 10f;
			}
    			
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
