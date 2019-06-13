using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFriend : ItemClass
{


    public GameObject Player;
    private PlayerStats playerstat;
    private ItemMananger itemManager;

    public GhostFriendMovement ghostFriendMovement;

    // Start is called before the first frame update
    void Start()
    {
        SetIcon();
        Collect();
        name = "Ghost Friend";
        discription = "Call a ghost friend to help you, if it would like to";

        ghostFriendMovement = GetComponent<GhostFriendMovement>();
        ghostFriendMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
            setPlayer();
            ghostFriendMovement.enabled = true;
            GetComponent<GhostFriendMovement>().followTarget = Player;
        }
    }

    void setPlayer()
    {
        Player = getPlayer();
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();
    }
}
