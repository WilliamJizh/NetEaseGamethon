using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : Bolt.EntityBehaviour<IPlayerState>
{
    //Door is locked or not
    bool Lock;
    bool foundPlayer; 
    private  Transform TeleportPosition;
    GameObject playerTrans;

    
    public  float opentime;
 
    void Start()
    {
        bool foundPlayer = false;
        Lock = false;
        //First check if this is door 1 or door 2, then get the corresponding teleport position;
        if (this.gameObject.name == "Door1")
        {
            TeleportPosition = this.transform.parent.gameObject.transform.Find("Door2").Find("TeleportPosition");
        }
        if (this.gameObject.name == "Door2")
        {
            TeleportPosition = this.transform.parent.gameObject.transform.Find("Door1").Find("TeleportPosition");
        }
    }
    public override void SimulateOwner()
    {
        if(foundPlayer == true)
        {
            state.SetTransforms(state.PlayerTransform, playerTrans.gameObject.GetComponent<Transform>());
        }

    }
    // detect wether player has entered the door collider or not
    private void OnTriggerStay(Collider other)
    {
        //check if it's player or not, and is the doo unlocked, and press E to teleport;
        if(other.gameObject.tag == "Player" && !Lock)
        {
            CharacterMovement player = other.gameObject.GetComponent<CharacterMovement>();

            if (Input.GetKeyUp(KeyCode.E))
            {
               player.OpenDoor(opentime, TeleportPosition);
               
               
                }
        }
    }

    
}
