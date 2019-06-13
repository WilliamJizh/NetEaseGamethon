using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountTicket : ItemClass
{


    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats playerstat;
    private Shop shop;
    private float freemoney = 1;
    private float i =1;


    // Start is called before the first frame update
    void Start()
    {
        names = "印钞机";
        SetIcon();
        Collect();

    }
   
    // Update is called once per frame
    void Update()
    {
			setPlayer();
			if(i>0){
				 i -= Time.deltaTime;
				 }
			else if(i <= 0){
			 playerstat.money += freemoney;
					i = 5;
				
			}
			
    }



        void setPlayer()
    {
        player = getPlayer();
        playerstat = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
        shop = player.GetComponent<Shop>();
    }

}
