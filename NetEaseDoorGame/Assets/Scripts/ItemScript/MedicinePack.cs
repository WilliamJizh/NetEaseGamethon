using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinePack : ItemClass
{
    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats pstats;
    public float diffHealth;


    void Awake()
    {
    	  pstats = GetComponent<PlayerStats>();
        itemMananger = GetComponent<ItemMananger>();

    }
    // Start is called before the first frame update
    void Start()
    {
        names = "抚灵丹";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
    	  diffHealth = pstats.maxHealth - pstats.currentHealth;
    	  
        if (collected)
        {
        	   if(diffHealth>20){
            IncreaseHealth();
            }
            
            else if(diffHealth<=20 && diffHealth>0){
            FillHealth();
            }
            
            if(pstats.currentHealth > pstats.maxHealth){
            FillHealth();
            }
            
            collected = false;
        }
    }
    void IncreaseHealth()
    {
        //increase player's health by 20
			pstats.currentHealth += 20;
    }
    void FillHealth(){
       // fill the blank
       pstats.currentHealth = pstats.maxHealth;
    }

}
