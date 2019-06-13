using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class DoorManager : Bolt.EntityEventListener<IDoorState>
{

    public bool globallock = true;

    public float dooropentime;
    public float doorlocktime;
    public bool doorlock = true;

    public float timer;

    public int todoor;
    
    
    DoorTeleport door1;
    DoorTeleport door2;


    List<GameObject> playerlist;

    ItemDropManager itemmanager;
    // Start is called before the first frame update
    void Start()
    {
        playerlist = new List<GameObject>(); 
        door1 = gameObject.transform.Find("Door1").GetComponent<DoorTeleport>();
        door2 = gameObject.transform.Find("Door2").GetComponent<DoorTeleport>();
        door1.opentime = dooropentime;
        door2.opentime = dooropentime;

        itemmanager = GameObject.Find("DropManager").GetComponent<ItemDropManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globallock) {
            doorlock = true;
            return;
        } 
       if (timer > 0) {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) {
            doorlock = false;
        }
       
    }

    public void SetDoorLock(GameObject player) {

        

        var doorlockevent = DoorOpen.Create(entity);
        if (todoor == 1) {
            doorlockevent.ItemSpawn = door2.TeleportPosition.position;
        }
        else
        {
            doorlockevent.ItemSpawn = door1.TeleportPosition.position;
        }

        if (playerlist.Contains(player))
        {
            doorlockevent.IsSpawn = false;
        }
        else {
            doorlockevent.IsSpawn = true;
            playerlist.Add(player);
        }
        
        doorlockevent.Itemid = itemmanager.RandomDrop();
        doorlockevent.Send();
        
    }

    public override void OnEvent(DoorOpen evnt)
    {
        doorlock = true;
        timer = doorlocktime;
        if(evnt.IsSpawn)
        itemmanager.ItemSpawn((int)evnt.Itemid,evnt.ItemSpawn);
    }

    public override void OnEvent(GlobalOpenDoor evnt)
    {
        globallock = false;
        doorlock = false;
    }

    public void GloabalUnlock() {
        var globalunlock = GlobalOpenDoor.Create(entity);
        globalunlock.Send();
        Debug.Log("msg sent");

    }


    /*public IEnumerator DoorUnlock() {

        yield return new WaitForSeconds(doorlocktime);

        doorlock = false;
    }*/


}
