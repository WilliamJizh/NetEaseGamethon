using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireBat : ItemClass
{
    public GameObject player;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        names = "吸血蝙蝠";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            
        }
    }
}
