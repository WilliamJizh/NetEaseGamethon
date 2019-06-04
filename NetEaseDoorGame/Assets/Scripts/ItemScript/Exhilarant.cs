using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhilarant : ItemClass
{

    public GameObject player;
    private BasicRangeAttack basicRangeAttack;
    

    void Awake()
    {
        


    }
    // Start is called before the first frame update
    void Start()
    {
    	names = "兴奋剂";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {

            setPlayer();
            IncreaseFireRate();
            collected = false;
        }
    }

    void IncreaseFireRate()
    {
        //the variable firearate is actually the pause time between two fires. 
        //So the smaller the firearate is, the faster the fire goes.
        
        basicRangeAttack.firearate *= 0.8f;
    }

    void setPlayer()
    {
        player = getPlayer();
        
        basicRangeAttack = player.GetComponent<BasicRangeAttack>();

    }
}
