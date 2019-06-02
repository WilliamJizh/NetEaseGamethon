using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Bolt.EntityBehaviour<IProjectileState>
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

  
   
    //set a timer to control the fire range
   public float existtime = 3;

    public override void Attached()
    {
        
        rb = GetComponent<Rigidbody>();
        state.SetTransforms(state.ProjectilePosition, transform);
    }


    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Projectile destroy timer
        entity.DestroyDelayed(existtime);
    }
    


    

    

}
