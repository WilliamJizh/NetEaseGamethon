using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPlus : MonoBehaviour
{
   
    public float healthGen;
    PlayerStats playerstat;

    // Start is called before the first frame update
    void Start()
    {
        playerstat = GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            healthGen = healthGen + 20;
            GetComponent<PlayerStats>().currentHealth = healthGen;
           Destroy(this.gameObject);
           Debug.Log(healthGen);
        }
    }

}
