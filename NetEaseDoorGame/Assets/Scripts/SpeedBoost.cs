using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : ItemClass
{

    public GameObject player;
    private PlayerStats characterMovement;
    private ItemMananger itemMananger;


    void Awake()
    {
        //temp implementation (player should get from collision)
        player = GameObject.Find("Player");
        characterMovement = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();

    }
    // Start is called before the first frame update
    void Start()
    {
        names = "加速鞋";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        if (collected == true)
        {
            IncreaseSpeed();
            collected = false;
        }
    }
    void IncreaseSpeed()
    {
        //increase player's movement speed by 10%
        float speed = 1.1f * characterMovement.speed;
        characterMovement.speed = speed;



    }

}