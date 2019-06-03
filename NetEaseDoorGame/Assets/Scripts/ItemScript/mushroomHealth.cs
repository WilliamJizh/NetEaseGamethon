using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomHealth : MonoBehaviour
{



    PlayerStats playerstat;

    public float mushroomHealthGen = 5f;
    float CountDownTimer = 5f;

  

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

     

        isTriggered = false;



       
        Debug.Log("Same Position Bruh");
    }

    // Update is called once per frame
    void Update()
    {

        playerCurrentPos = this.transform.position;
       


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


                }
                else
                {

                    playerstat.currentHealth += mushroomHealthGen * Time.deltaTime;
                    if(playerstat.currentHealth >= playerstat.maxHealth)
                    {
                        playerstat.currentHealth = playerstat.maxHealth;
                    }
                }

                playerPos = playerCurrentPos;


            }

            else if(CountDownTimer <= 0f) 
            {
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
