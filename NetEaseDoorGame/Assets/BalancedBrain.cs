using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancedBrain : ItemClass
{


    public GameObject Player;
    private PlayerStats playerstat;
    private ItemMananger itemManager;



    // Start is called before the first frame update
    void Start()
    {
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
           setPlayer();
            playerstat.newTransform.transform.localScale = new Vector3(2, 2, 2);
            
             
        }
    }

    void setPlayer()
    {
        Player = getPlayer();
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();


    }
}
