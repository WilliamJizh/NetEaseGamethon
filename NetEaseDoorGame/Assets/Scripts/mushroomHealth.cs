using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomHealth : ItemClass
{


    public GameObject Player;
    PlayerStats playerstat;
    ItemMananger itemManager;

    public float mushroomHealthGen = 5f;
    float CountDownTimer = 5f;

  

    bool isTriggered;
    

    public Vector3 playerPos;
    public Vector3 playerCurrentPos;


    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.Find("Player");
        playerPos = this.transform.position;
        playerstat = Player.GetComponent<PlayerStats>();
        itemManager = Player.GetComponent<ItemMananger>();
    }




    void Start()
    {
        SetIcon();
        Collect();

        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {

        playerCurrentPos = this.transform.position;
       


        if (collected == true) 
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
                collected = false;
                CountDownTimer = 5f; 
            }
        }



    }



}
