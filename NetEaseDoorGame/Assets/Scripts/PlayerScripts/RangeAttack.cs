using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RangeAttack : Bolt.EntityEventListener<IPlayerState>
{
   [SerializeField]
    GameObject Projectileprefeb;
    [SerializeField]
    string rangeattackinput = "Fire1";

    public Joystick joystick;
    // Temp instantiate position modifier 
    [SerializeField]
    float offset;
    // Fire rate package
    [SerializeField]
    public float firearate = 0.4f;
    [SerializeField]
    float nextfire = 0;
    [SerializeField]
    float turntime = 0.1f;

    PlayerStats playerstat;

    Vector3 lookdir;
    Vector3 lookdir1;
    Vector3 lookdir2;
    Vector3 lookdir3;

    GameObject ui;

    string rightjoystickx = "Mouse X";
    string rightjoysticky = "Mouse Y";

    public AudioSource attackSound;

    public override void Attached()
    {
        offset = 2f;

        playerstat = GetComponent<PlayerStats>();
        
        joystick = GameObject.Find("Dynamic Joystick R").GetComponent<Joystick>();
        if (joystick != null) Debug.Log("found!");
    }


    public override void SimulateOwner()
    {
        if (!entity.IsOwner) return;

        GetDir();
        Fire();
    }


    void GetDir() {
        
        if (Mathf.Abs(Input.GetAxis(rightjoystickx)) < Mathf.Abs(joystick.Horizontal)) 
            lookdir.x = joystick.Horizontal;
            else lookdir.x = Input.GetAxis(rightjoystickx);
        if (Mathf.Abs(Input.GetAxis(rightjoysticky)) < Mathf.Abs(joystick.Vertical))
            lookdir.z = joystick.Vertical;
            else lookdir.z = Input.GetAxis(rightjoysticky);

        lookdir1.x = 0 - lookdir.x;
        lookdir1.z = 0 - lookdir.z;
    }

    void Fire()
    {
        if (lookdir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookdir), turntime);
            
            if (Time.time > nextfire && playerstat.currStamina >= playerstat.attackcost)
            {
                // create a range attack event
                var shoot = RangeAttackEvent.Create(entity);
                shoot.Attackdirection = lookdir;
                shoot.Send();



                

                nextfire = Time.time + playerstat.firearate;

            }

        }
    }

    // on rangeattack event callback
    public override void OnEvent(RangeAttackEvent evnt)
    {
        FireAction();
    }


    void FireAction()
    {
        playerstat.currStamina -= playerstat.attackcost;
        attackSound.Play();

        Instantiate(Projectileprefeb, transform.position + transform.forward * offset, transform.rotation)
            .GetComponent<Projectile>().SetShooter(this.gameObject);
  
    }


}
