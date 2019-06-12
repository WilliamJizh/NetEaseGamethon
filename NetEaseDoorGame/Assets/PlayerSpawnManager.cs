using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public bool start;

    public GameObject[] players;
    public int maxPlayerNum;
    GameObject[] playerspawns;
   
    // Start is called before the first frame update
    void Start()
    {
        maxPlayerNum = 3;
        players = new GameObject[3];
 
        playerspawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");

    }

    // Update is called once per frame
    void Update()
    {



            players= GameObject.FindGameObjectsWithTag("Player");
           
            for (int i = 0; i<maxPlayerNum; i++)
            {
                players[i].transform.position = playerspawns[i].transform.position;
           
            }

         

        
       
    }
}
