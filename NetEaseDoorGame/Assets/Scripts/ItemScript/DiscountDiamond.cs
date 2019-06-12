using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountDiamond : ItemClass
{


    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats playerstat;
    private Shop shop;



    // Start is called before the first frame update
    void Start()
    {
        names = "抵用钻石";
        SetIcon();
        Collect();

    }

    void ChangeBack(){
    shop.DiscountRate = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
        		setPlayer();
            ChangeRate();
        }
        if(!collected){
        		setPlayer();
        		ChangeBack();
        }
    }
    void ChangeRate()
    {
        //30% off for next purchase.
        shop.DiscountRate = 0.7f;
    }
        void setPlayer()
    {
        player = getPlayer();
        playerstat = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
        shop = player.GetComponent<Shop>();
    }
}
