using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : ItemClass
{

    public GameObject player;
    private PlayerStats playerStats;

    void Awake()
    {
           
           
    }
    // Start is called before the first frame update
    void Start()
    {
        names = "眼睛";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            setPlayer();
            IncreaseAttackRange();
            //If player collected eye, then set the boolean logic to false.
            collected = false;
        }
    }

    //increase player's attack range after collecting eye item
    void IncreaseAttackRange()
    {
        playerStats.existtime += 0.3f;
    }

    //设置具体是哪个player拿到了，并且access那个player的stats
    void setPlayer()
    {
        player = getPlayer();
        playerStats = player.GetComponent<PlayerStats>();
        
    }
}
