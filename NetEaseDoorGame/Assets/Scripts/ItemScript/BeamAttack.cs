using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : ItemClass
{
    public GameObject player;
    private PlayerStats characterMovement;
    private ItemMananger itemMananger;



    // Start is called before the first frame update
    void Start()
    {
        names = "激光镜";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        if (collected == true)
        {
            setPlayer();
        
        }
    }

    void setPlayer()
    {

        player = getPlayer();

    }
 
}
