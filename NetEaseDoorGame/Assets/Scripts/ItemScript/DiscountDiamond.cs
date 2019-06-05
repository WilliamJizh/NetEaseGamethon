using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountDiamond : ItemClass
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
        names = "抵用钻石";
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
        //30% off for next purchase.
        DiscountRate = 0.7f;
    }
        void setPlayer()
    {
        player = getPlayer();
        playerstat = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();
    }
}
