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
        healthGen = playerstat.initialHealth;

    }

    // Update is called once per frame
    void Update()
    {
        playerstat.currentHealth = healthGen;
    }
   
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("AddHealth"))
        {
           healthGen = healthGen + 20;
           Destroy(col.gameObject);
        }
    }

}
