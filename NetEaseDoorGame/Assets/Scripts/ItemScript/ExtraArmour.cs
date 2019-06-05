using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraArmour : ItemClass
{
    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats pstats;
    public float diffArmour;


    void Awake()
    {
    	  pstats = GetComponent<PlayerStats>();

    }
    // Start is called before the first frame update
    void Start()
    {
        names = "秋裤";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
    	  diffArmour = pstats.currentArmour - pstats.initialArmour;
    	  
        if (collected)
        {
       	 setPlayer();
        	   if(diffArmour>20 && diffArmour<=40){
            FillArmour();
            }
            
            else if(diffArmour<=20 && diffArmour>=0){
            IncreaseArmour();
            }
            
            if(pstats.currentArmour > pstats.maxArmour){
            FillArmour();
            }
            
            collected = false;
        }
    }
    void IncreaseArmour()
    {
        //increase player's health by 20
			pstats.currentArmour += 20;
    }
    void FillArmour(){
       // fill the blank
       pstats.currentArmour = pstats.maxArmour;
    }
        void setPlayer()
    {
        player = getPlayer();
        pstats = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
    }
}
