using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscountTicket : ItemClass
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
            ChangeRate();
        }
        if(!collected){
        		ChangeBack();
        }
    }
    void ChangeRate()
    {
        //100% off for next purchase.
        DiscountRate = 0.0f;
    }

}
