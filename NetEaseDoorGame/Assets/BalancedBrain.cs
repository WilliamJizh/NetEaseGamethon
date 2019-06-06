using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancedBrain : ItemClass
{
    [SerializeField]
    float setSize = 2f;
    [SerializeField]
    float setSpeed = 15f;

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
            playerstat.projectileSize = setSize;
            playerstat.projectileSpeed = setSpeed;
            
             
        }
    }

    void setPlayer()
    {
        Player = getPlayer();
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();


    }
}
