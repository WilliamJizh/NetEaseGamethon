using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

    //set a timer to control the fire range
    float timer;
    //set a timeModifier so that we can change attack range by changing this modifier
    public float timeModifier = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer += 1.0f * Time.deltaTime;
        //if timer is larger than the default time: 0.3f, then destroy projectile
        if (timer > timeModifier)
        {
            GameObject.Destroy(this.gameObject);
        }
       
    }
}
