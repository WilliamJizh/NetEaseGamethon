﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangeAttack : Bolt.EntityEventListener<ICubeState>
{
    [SerializeField]
    public GameObject projectileprefeb;

    [SerializeField]
    string rangeattackinput = "Fire1";

    public Joystick joystick;
    // Temp instantiate position modifier 
    [SerializeField]
    float offset = 1;

    // Fire rate package
    [SerializeField]
    public float firearate = 0.1f;
    [SerializeField]
    float nextfire = 0;
    [SerializeField]
    float turntime = 0.1f;


  

    Vector3 lookdir;

    GameObject ui;
    


    private void Awake()
    {
        joystick = GameObject.Find("Dynamic Joystick R").GetComponent<Joystick>();
        if (joystick != null) Debug.Log("found!");
    }



    void GetDir() {
        lookdir.x = joystick.Horizontal;
        lookdir.z = joystick.Vertical;
    }

    void Fire()
    {
        if (lookdir != Vector3.zero && entity.IsOwner)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookdir), turntime);
            if (Time.time > nextfire)
            {

                BoltNetwork.Instantiate(BoltPrefabs.Sphere, transform.position + transform.forward * offset, transform.rotation);
                nextfire = Time.time + firearate;

            }

        }
    }

    public override void OnEvent(RangeAttack evnt)
    {
        //
    }
}