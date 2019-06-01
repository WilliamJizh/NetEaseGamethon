using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangeAttack : MonoBehaviour
{
    [SerializeField]
    GameObject projectileprefeb;

    [SerializeField]
    string rangeattackinput = "Fire1";

    public Joystick joystick;

    // Temp instantiate position modifier 
    [SerializeField]
    float offset = 1;

    // Fire rate package
    [SerializeField]
    float firearate = 0.1f;
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

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        GetDir();
        Fire();
    }

    void GetDir() {
        lookdir.x = joystick.Horizontal;
        lookdir.z = joystick.Vertical;
    }

    void Fire()
    {
        if (lookdir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookdir), turntime);

            if (Time.time > nextfire)
            {
                Debug.Log("Fire");
                Instantiate(projectileprefeb, transform.position + transform.forward * offset, transform.rotation);
                nextfire = Time.time + firearate;
            }
        }
    }
}
