using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Bolt.EntityBehaviour<IProjectileState>
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

  
    [SerializeField]
    //set a timer to control the fire range
    float existtime = 3;

    public override void Attached()
    {
        
        rb = GetComponent<Rigidbody>();
    }


    public override void SimulateOwner()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Projectile destroy timer
        StartCoroutine(ExistTimer());
    }

    IEnumerator ExistTimer() {
        
        yield return new WaitForSecondsRealtime(existtime);
        Destroy(this.gameObject);

    }

    

}
