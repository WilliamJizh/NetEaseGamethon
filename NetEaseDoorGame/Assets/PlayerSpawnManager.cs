using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public bool start;
    public GameObject[] cameras;
    public GameObject[] players;
    public int maxPlayerNum;
    GameObject[] playerspawns;
   
    // Start is called before the first frame update
    void Start()
    {
        maxPlayerNum = 3;
        players = new GameObject[3];
        cameras = new GameObject[3];
        playerspawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
    }

    // Update is called once per frame
    void Update()
    {

        if (!start)
        {

            players= GameObject.FindGameObjectsWithTag("Player");
            cameras = GameObject.FindGameObjectsWithTag("MainCamera");
            for (int i = 0; i<maxPlayerNum; i++)
            {
                players[i].transform.position = playerspawns[i].transform.position;
                if (cameras[i] != null)
                {
                    cameras[i].transform.position = playerspawns[i].transform.GetChild(0).transform.position;
                }
            }

            if (players[maxPlayerNum-1] != null)
            {

                start = true;
            }

        }
        if (start)
        {
            BoltNetwork.LoadScene("MasterLevel2");
        }
    }
}
