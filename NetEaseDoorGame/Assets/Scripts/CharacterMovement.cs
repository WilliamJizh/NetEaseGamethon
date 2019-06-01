using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : Bolt.EntityBehaviour<ICubeState>

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

    GameObject ui;

    private void Awake()
    {
        joystick = GameObject.Find("Dynamic Joystick L").GetComponent<Joystick>();
        if (joystick != null) Debug.Log("found!");

        charactercontroller = GetComponent<CharacterController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (charactercontroller.isGrounded) {
            movedirection.x = joystick.Horizontal;
            movedirection.z = joystick.Vertical;
            movedirection.y = 0;
            movedirection *= speed;
            
        }

       

        movedirection.y -= gravity * Time.deltaTime;
        charactercontroller.Move(movedirection * Time.deltaTime);
    }
}
