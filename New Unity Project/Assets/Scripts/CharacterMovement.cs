using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    CharacterController charactercontroller;

    Vector3 movedirection;

    [SerializeField]
    float speed = 10;
    [SerializeField]
    float gravity = 10;
    



    [SerializeField]
    string horizontalinput = "Horizontal";
    [SerializeField]
    string verticalinput = "Vertical";
    



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
            movedirection.x = Input.GetAxis(horizontalinput);
            movedirection.z = Input.GetAxis(verticalinput);
            movedirection.y = 0;
            movedirection *= speed;
            
        }

        if (movedirection.x != 0 || movedirection.z != 0) {
            transform.rotation = Quaternion.LookRotation(movedirection) ;
        }

        movedirection.y -= gravity * Time.deltaTime;
        charactercontroller.Move(movedirection * Time.deltaTime);
    }
}
