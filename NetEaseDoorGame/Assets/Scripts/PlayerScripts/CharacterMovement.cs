using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : Bolt.EntityBehaviour<IPlayerState>

{
    CharacterController charactercontroller;

    [SerializeField]
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
    string rollinput = "Fire2";

    public Vector3 playerPosition;
    public Transform teleportPosition;
    public bool teleported;

    [SerializeField]
    float opendoortimer;

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


        charactercontroller = GetComponent<CharacterController>();
        playerstats = GetComponent<PlayerStats>();
        
    }

    public override void SimulateOwner()
    {

        switch (playerstats.currState) {

            case PlayerState.Normal:
                Movement();
                TeleportManager();
                RollActivate();
                break;

            case PlayerState.Roll:
                Roll();
                break;

            case PlayerState.OpenDoor:
                RollActivate();
                Opening();

                break;


        }
   
        
    }

   

    void GetDir() {
        if (Mathf.Abs(Input.GetAxis(leftjoystickx)) < Mathf.Abs(joystick.Horizontal))
            movedirection.x = joystick.Horizontal;
        else movedirection.x = Input.GetAxis(leftjoystickx);
        if (Mathf.Abs(Input.GetAxis(leftjoysticky)) < Mathf.Abs(joystick.Vertical))
            movedirection.z = joystick.Vertical;
        else movedirection.z = Input.GetAxis(leftjoysticky);
    }

    void RollActivate() {
        if (Input.GetButtonDown(rollinput) && playerstats.currStamina > playerstats.rollcost) {
            Debug.Log("Roll!");
            playerstats.currState = PlayerState.Roll;
            playerstats.immune = true;
            speed = playerstats.Speed * 5;
            GetDir();
            StartCoroutine(ResetNormal());
            playerstats.currStamina -= playerstats.rollcost;
        }
        
    }

    IEnumerator ResetNormal() {
        yield return new WaitForSecondsRealtime(playerstats.rolllasttime);
        playerstats.currState = PlayerState.Normal;
        playerstats.immune = false;
    }

    void Roll()
    {
        if (charactercontroller.isGrounded)
        {

            GetDir();
            movedirection.y = 0;
            movedirection.Normalize();
            movedirection *= speed;

        }

        movedirection.y -= gravity * Time.deltaTime;
        charactercontroller.Move(movedirection * Time.deltaTime);


    }

    void Movement()
    {
        GetDir();
       

        if (charactercontroller.isGrounded) {

            
            movedirection.y = 0;
            movedirection.Normalize(); 
            movedirection *= playerstats.Speed;
            
        }
        

        movedirection.y -= gravity * Time.deltaTime;
        charactercontroller.Move(movedirection * Time.deltaTime);
    }

    void TeleportManager() {


        if (teleported == true)
        {
            Teleport(teleportPosition);
            teleported = false;
        }
    }

    public void Teleport(Transform TeleportPos)
    {

        //把玩家传送到另一个门
        Vector3 pos = transform.position;
        pos.x = TeleportPos.position.x;
        pos.z = TeleportPos.position.z;
        transform.position = pos;

    }

    void Opening() {
        opendoortimer -= Time.deltaTime;
        if (opendoortimer <= 0) {
            teleported = true;
            currdoor.SetDoorLock(this.gameObject);
            playerstats.currState = PlayerState.Normal;
        }
    }

    DoorManager currdoor;
    public void OpenDoor(float opentime, Transform targettransform, DoorManager doormanager) {
        playerstats.currState = PlayerState.OpenDoor;
        opendoortimer = opentime;
        teleportPosition = targettransform;
        currdoor = doormanager;
        
    }


    }
