using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPlus : ItemClass
{

    public GameObject Player;
    private PlayerStats playerstat;
    private ItemMananger itemManager;
    public float meatHealthGen = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        playerstat = GetComponent<PlayerStats>();
        collected = false;
		 name= "Drum Stick";
        discription = "Regenerate health passively";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
            setPlayer();
            playerstat.currentHealth += meatHealthGen * Time.deltaTime;


       
        }
    }
   
   
   

    void setPlayer()
    {
        Player = getPlayer();
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();
    }


}
