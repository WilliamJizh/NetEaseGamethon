﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorManager : MonoBehaviour
{


    public float dooropentime;
    public float doorlocktime;
    public bool doorlock = false;

   


    DoorTeleport door1;
    DoorTeleport door2;
    // Start is called before the first frame update
    void Start()
    {
   
        door1 = gameObject.transform.Find("Door1").GetComponent<DoorTeleport>();
        door2 = gameObject.transform.Find("Door2").GetComponent<DoorTeleport>();
        door1.opentime = dooropentime;
        door2.opentime = dooropentime;

       
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void SetDoorLock() {
        doorlock = true;
        StartCoroutine(DoorUnlock());
    }

    public IEnumerator DoorUnlock() {

        yield return new WaitForSeconds(doorlocktime);

        doorlock = false;
    }
}
