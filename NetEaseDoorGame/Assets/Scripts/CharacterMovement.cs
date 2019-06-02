using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : Bolt.EntityBehaviour<IPlayerState>

{
    CharacterController charactercontroller;

    Vector3 movedirection;

    [SerializeField]
    public float speed = 10;
    [SerializeField]
    float gravity = 10;


    public Joystick joystick;

    

    [SerializeField]
    float turntime = 0.1f;

    PlayerStats playerstats;

    GameObject ui;

    string leftjoystickx = "Horizontal";
    string leftjoysticky = "Vertical";
    public Vector3 playerPosition;
    public Transform teleportPosition;
    public bool teleported;
    public override void Attached()
    {
        joystick = GameObject.Find("Dynamic Joystick L").GetComponent<Joystick>();
        if (joystick != null) Debug.Log("found!");

        charactercontroller = GetComponent<CharacterController>();
        state.SetTransforms(state.PlayerTransform, transform);
        playerstats = GetComponent<PlayerStats>();
    }

    private void Awake()
    {
        joystick = GameObject.Find("Dynamic Joystick L").GetComponent<Joystick>();
        if (joystick != null) Debug.Log("found!");

        charactercontroller = GetComponent<CharacterController>();
        playerstats = GetComponent<PlayerStats>();
    }

    public override void SimulateOwner()
    {

       

        Movement();
        if (teleported == true)
        {

            Teleport(teleportPosition);
            teleported = false;
        }
        //  Teleport();
    }

    private void Update()
    {
   
       
        Movement();
        //Teleport();
    }

    void Movement()
    {
        if (charactercontroller.isGrounded) {

            if(Mathf.Abs(Input.GetAxis(leftjoystickx))<Mathf.Abs(joystick.Horizontal))
            movedirection.x = joystick.Horizontal;
            else movedirection.x = Input.GetAxis(leftjoystickx);
            if (Mathf.Abs(Input.GetAxis(leftjoysticky)) < Mathf.Abs(joystick.Vertical))
            movedirection.z = joystick.Vertical;
            else movedirection.z = Input.GetAxis(leftjoysticky);
            movedirection.y = 0;
            movedirection *= playerstats.speed;
            
        }

        

        movedirection.y -= gravity * Time.deltaTime;
        charactercontroller.Move(movedirection * Time.deltaTime);
    }
    public void Teleport(Transform TeleportPos)
    {

        //把玩家传送到另一个门

        //state.SetTransforms(state.PlayerTransform, transform);
        Vector3 pos = transform.position;
        pos.x = TeleportPos.position.x;
        pos.z = TeleportPos.position.z;
        transform.position = pos;

    }



    }
