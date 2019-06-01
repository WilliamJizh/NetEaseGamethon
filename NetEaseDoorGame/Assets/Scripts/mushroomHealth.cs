using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomHealth : MonoBehaviour
{



    PlayerStats playerstat;

    public float mushroomHealthGen;
    float CountDownTimer;
    public float healthG;
  

    bool isTriggered;

    public Vector3 playerPos;
    public Vector3 playerCurrentPos;


    // Start is called before the first frame update
    private void Awake()
    {
        playerPos = this.transform.position;
    }




    void Start()
    {
        playerstat = GetComponent<PlayerStats>();
        CountDownTimer = 5f;
        healthG = playerstat.initialHealth;

        isTriggered = false;



       
        Debug.Log("Same Position Bruh");
    }

    // Update is called once per frame
    void Update()
    {

        playerCurrentPos = this.transform.position;
        healthG = playerstat.currentHealth;  


        if (isTriggered == true) 
        {

            CountDownTimer -= Time.deltaTime;


            if(CountDownTimer>0f && CountDownTimer< 5f) 
            {
                //here is the healthing part

                if (playerPos.x < playerCurrentPos.x ||
                    playerPos.x > playerCurrentPos.x ||
                    playerPos.z < playerCurrentPos.z ||
                    playerPos.z > playerCurrentPos.z)

                {

                    playerstat.currentHealth = healthG;
                }
                else
                {
                    mushroomHealthGen = mushroomHealthGen + 5 * Time.deltaTime;
                    healthG = healthG + mushroomHealthGen;
                    

                }

                playerPos = playerCurrentPos;


            }

            else if(CountDownTimer <= 0f) 
            {
                mushroomHealthGen = 0;
                isTriggered = false;
                CountDownTimer = 5f; 
            }
        }



    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Mushroom")) 
        {
            isTriggered = true;
            Destroy(col.gameObject);
           
        }

    }
}
