using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicinePack : ItemClass
{
    public GameObject player;
    private ItemMananger itemMananger;
    private PlayerStats pstats;


    void Awake()
    {
    	  pstats = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();

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
        if (collected)
        {
            IncreaseHealth();
            collected = false;
        }
    }
    void IncreaseHealth()
    {
        //increase player's health by 25
			pstats.health += 25;
    }

}
