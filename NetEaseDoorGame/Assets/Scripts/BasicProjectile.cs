using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Bolt.EntityBehaviour<IProjectileState>
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

    //set a timer to control the fire range
    float timer;
    //set a timeModifier so that we can change attack range by changing this modifier
    public float timeModifier = 0.3f;

    [SerializeField]
    float existtime = 3;

    public override void Attached()
    {
        
        rb = GetComponent<Rigidbody>();
    }


    public override void SimulateOwner()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
<<<<<<< HEAD
        timer += 1.0f * Time.deltaTime;
        //if timer is larger than the default time: 0.3f, then destroy projectile
        if (timer > timeModifier)
        {
            GameObject.Destroy(this.gameObject);
        }
       
=======
        // Projectile destroy timer
        StartCoroutine(ExistTimer());
    }

    IEnumerator ExistTimer() {
        
        yield return new WaitForSecondsRealtime(existtime);
        Destroy(this.gameObject);
>>>>>>> 4c9d2e031c0d409324e157031a6f2d26e6d9cb26
    }

    

}
