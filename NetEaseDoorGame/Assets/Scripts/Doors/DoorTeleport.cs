using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : Bolt.EntityBehaviour<IPlayerState>
{
    //Door is locked or not
    bool Lock;
    bool foundPlayer; 
    public  Transform TeleportPosition;
    GameObject playerTrans;
    DoorManager doormanager;
    
    public float opentime;

    AudioSource DoorOpenSource;

    int todoornum;
    void Awake()
    {
        GameObject DoorSound = GameObject.Find("DoorOpen");
        DoorOpenSource = DoorSound.GetComponent<AudioSource>();


        doormanager = transform.parent.gameObject.GetComponent<DoorManager>();
        opentime = doormanager.dooropentime;

        bool foundPlayer = false;
        
        //First check if this is door 1 or door 2, then get the corresponding teleport position;
        if (this.gameObject.name == "Door1")
        {
            todoornum = 2;
            TeleportPosition = this.transform.parent.gameObject.transform.Find("Door2").Find("TeleportPosition");
        }
        if (this.gameObject.name == "Door2")
        {
            todoornum = 1;
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
        if (other.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.E) && !doormanager.doorlock)
            {
                CharacterMovement player = other.gameObject.GetComponent<CharacterMovement>();
                player.OpenDoor(opentime, TeleportPosition,doormanager);
                doormanager.todoor = todoornum;
                DoorOpenSource.Play();
            }
        }
    }


}
