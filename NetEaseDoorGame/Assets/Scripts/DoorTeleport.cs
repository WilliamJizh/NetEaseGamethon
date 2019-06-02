using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    //Door is locked or not
    bool Lock;
  private  Transform TeleportPosition;

    void Start()
    {
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


    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.E)&& !Lock)
        {
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject player) {



         Vector3 pos = player.GetComponent<Transform>().position;
        pos.x = TeleportPosition.position.x;
        pos.z = TeleportPosition.position.z;
        player.GetComponent<Transform>().position = pos;
    }
}
