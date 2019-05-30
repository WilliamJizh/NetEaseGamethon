using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : ItemClass
{
 
    public GameObject player;
    private CharacterMovement characterMovement;
    private ItemMananger itemMananger;
  

    void Awake()
    {
        characterMovement = player.GetComponent<CharacterMovement>();
        itemMananger = player.GetComponent<ItemMananger>();

    }
    // Start is called before the first frame update
    void Start()
    {
        names = "speedboost";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            IncreaseSpeed();
            collected = false;
        }
    }
    void IncreaseSpeed()
    {
        //increase player's movement speed by 10%
        float speed = 1.001f * characterMovement.speed;
        characterMovement.speed = speed;



    }

}