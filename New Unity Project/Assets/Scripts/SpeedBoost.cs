using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : ItemClass
{
 
    public GameObject player;
    private CharacterMovement characterMovement;

  

    void Awake()
    {
        characterMovement = player.GetComponent<CharacterMovement>();


    }
    // Start is called before the first frame update
    void Start()
    {
    
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            IncreaseSpeed();
            //If player collected speedboost, then set the logic to false.
            collected = false;
        }
    }
    void IncreaseSpeed()
    {
        //increase player's movement speed by 2 when player picks up this itemf
        characterMovement.speed += 0.2f;
        



    }

}