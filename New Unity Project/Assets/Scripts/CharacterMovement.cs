using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    CharacterController charactercontroller;

    Vector3 movedirection;

    [SerializeField]
<<<<<<< HEAD
public  float speed = 10;
=======
    public float speed = 10;
>>>>>>> 9e3a0a52a70970f6747f4a96b897d700cd03bd49
    [SerializeField]
    float gravity = 10;


    public Joystick joystick;

    

    [SerializeField]
    float turntime = 0.1f; 


    // Start is called before the first frame update
    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
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
