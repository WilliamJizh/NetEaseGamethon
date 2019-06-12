using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDonationAltar : MonoBehaviour
{
    public GameObject VampireBat, Easter, Exhilarant, Eye, HealthPlus, MilkNBread, Mushroom, SpeedBoost;
    //temp position used to make it appear in front of the shop object
    Vector3 temPos;

    //spawn prefabs once per 2 seconds
    public float spawnRate = 2f;

    //variable to set next spawn time
    float nextSpawn = 0f;

    //variable to contain random value
    int whatToSpawn;

    //other variable that is needed
    GameObject player;
    PlayerStats playerStats;
    int triggertime = 0;
    

    // Start is called before the first frame update
    void Start()
    {

        //adjust spawn position
        temPos = transform.position;
        temPos.z -= 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if ( triggertime == 1)
        {

            whatToSpawn = Random.Range(1, 8);


            SetCollider();
            triggertime = 0;

            //NEED TO REVISE PRICE FOR EACH ITEM 


            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(VampireBat, temPos, Quaternion.identity);
                    return;
                case 2:
                    Instantiate(Easter, temPos, Quaternion.identity);

                    return;
                case 3:
                    Instantiate(Exhilarant, temPos, Quaternion.identity);

                    return;
                case 4:
                    Instantiate(Eye, temPos, Quaternion.identity);

                    return;
                case 5:
                    Instantiate(HealthPlus, temPos, Quaternion.identity);

                    return;
                case 6:
                    Instantiate(MilkNBread, temPos, Quaternion.identity);

                    return;
                case 7:
                    Instantiate(Mushroom, temPos, Quaternion.identity);

                    return;
                case 8:
                    Instantiate(SpeedBoost, temPos, Quaternion.identity);
                    return;

                    //If there are more items, add them below and change the random number range.





            }
        }

    }  
    //Interact with player if player arrives the shop

    void SetCollider()
    {

        this.gameObject.AddComponent<BoxCollider>();
        this.gameObject.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            triggertime = 1;
            player = other.gameObject;
            Debug.Log("You opened the treasure box!!");
            playerStats = player.GetComponent<PlayerStats>();


        }


    }
}
