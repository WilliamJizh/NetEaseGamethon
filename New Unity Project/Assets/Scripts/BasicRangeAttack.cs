using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangeAttack : MonoBehaviour
{
    [SerializeField]
    GameObject projectileprefeb;

    [SerializeField]
    string rangeattackinput = "Fire1";

    // Temp instantiate position modifier 
    [SerializeField]
    float offset = 1;

    // Fire rate package
    [SerializeField]
    float firearate = 0.1f;
    [SerializeField]
    float nextfire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetButton(rangeattackinput) && Time.time > nextfire)
        {
            Debug.Log("Fire");
            Instantiate(projectileprefeb,transform.position + Vector3.forward*offset,Quaternion.identity);
            nextfire = Time.time + firearate;
        }
    }
}
