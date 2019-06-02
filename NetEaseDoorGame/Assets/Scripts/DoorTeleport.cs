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
            Teleport(playerTrans);
        }

    }
    // detect wether player has entered the door collider or not
    private void OnTriggerStay(Collider other)
    {
        //check if it's player or not, and is the doo unlocked, and press E to teleport;
        if(other.gameObject.tag == "Player" && !Lock)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {

              
                other.gameObject.GetComponent<CharacterMovement>().teleportPosition = TeleportPosition;
                other.gameObject.GetComponent<CharacterMovement>().teleported =true;
               
             
              
               // Teleport(other.gameObject);
                }
        }
    }

    private void Teleport(GameObject player) {

        //把玩家传送到另一个门

        state.SetTransforms(state.PlayerTransform, transform);
        Vector3 pos = player.GetComponent<Transform>().position;
        pos.x = TeleportPosition.position.x;
        pos.z = TeleportPosition.position.z;
        player.GetComponent<Transform>().position = pos;
      




    }
}
