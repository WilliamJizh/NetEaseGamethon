using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorManager : Bolt.EntityEventListener<IDoorState>
{


    public float dooropentime;
    public float doorlocktime;
    public bool doorlock = false;

    public float timer;

    public int todoor;
    
    
    DoorTeleport door1;
    DoorTeleport door2;

    ItemDropManager itemmanager;
    // Start is called before the first frame update
    void Start()
    {
   
        door1 = gameObject.transform.Find("Door1").GetComponent<DoorTeleport>();
        door2 = gameObject.transform.Find("Door2").GetComponent<DoorTeleport>();
        door1.opentime = dooropentime;
        door2.opentime = dooropentime;

        itemmanager = GameObject.Find("ItemManager").GetComponent<ItemDropManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if (timer > 0) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            doorlock = false;
        }
       
    }

    public void SetDoorLock() {

        var doorlockevent = DoorOpen.Create(entity);
        if (todoor == 1) {
            doorlockevent.ItemSpawn = door2.TeleportPosition.position;
        }
        else
        {
            doorlockevent.ItemSpawn = door1.TeleportPosition.position;
        }


        doorlockevent.Itemid = itemmanager.RandomDrop();
        doorlockevent.Send();
        
    }

    public override void OnEvent(DoorOpen evnt)
    {
        doorlock = true;
        timer = doorlocktime;
        itemmanager.ItemSpawn((int)evnt.Itemid,evnt.ItemSpawn);
    }

   

   

    /*public IEnumerator DoorUnlock() {

        yield return new WaitForSeconds(doorlocktime);

        doorlock = false;
    }*/


}
