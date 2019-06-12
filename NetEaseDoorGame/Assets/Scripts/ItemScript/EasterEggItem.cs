using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggItem : ItemClass
{

    public GameObject player;
    private PlayerStats playerStats;
    private ItemMananger itemMananger;

    // Start is called before the first frame update
    void Start()
    {
        names = "复活鸡蛋";
        //如果要从文件读取sprite
        //使用 SetIcon(路径/“文件名”)；
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        if (collected == true)
        {
            
            setPlayer();
            playerStats.life += 1;
            collected = false;
        }

    }

    void setPlayer()
    {

        player = getPlayer();
        playerStats = player.GetComponent<PlayerStats>();
        itemMananger = player.GetComponent<ItemMananger>();

    }


    // public void OnTriggerEnter(Collider other);
}
