using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountDiamond : ItemClass
{


    public GameObject player;
    private ItemMananger itemMananger;
    public float DiscountRate;


    void Awake()
    {
        itemMananger = GetComponent<ItemMananger>();

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
            ChangeRate();
        }
        if(!collected){
        		ChangeBack();
        }
    }
    void ChangeRate()
    {
        //30% off for next purchase.
        DiscountRate = 0.7f;
    }
    
}
