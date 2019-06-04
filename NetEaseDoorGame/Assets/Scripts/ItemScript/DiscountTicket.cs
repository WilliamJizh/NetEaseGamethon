using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountTicket : ItemClass
{


    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats playerstat;
    public float DiscountRate;


    void Awake()
    {


    }
    // Start is called before the first frame update
    void Start()
    {
        names = "冥府通";
        SetIcon();
        Collect();

    }

    void ChangeBack(){
    DiscountRate = 1.0f;
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
        //100% off for next purchase.
        DiscountRate = 0.0f;
    }
        void setPlayer()
    {
        player = getPlayer();
        playerstat = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
    }

}
