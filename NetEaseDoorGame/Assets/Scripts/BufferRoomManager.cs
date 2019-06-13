using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BufferRoomManager : MonoBehaviour
{
    public bool start;
    public bool bufferState;

    public GameObject[] alivePlayers;
    public int maxPlayerNum;
     public GameObject[] bufferSpawn;
    public List<GameObject> bufferPlayers;


    // Start is called before the first frame update
    void Start()
    {
        maxPlayerNum = 2;


        bufferSpawn = GameObject.FindGameObjectsWithTag("BufferSpawn");
    }

    // Update is called once per frame
    void Update()
    {


        if (bufferState)
        {

            alivePlayers = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < bufferPlayers.Count; i++)
            {

                bufferPlayers[i].transform.position = bufferSpawn[i].transform.position;
          
            }

            if (bufferPlayers.Count==alivePlayers.Length)
            {

                start = true;
            }

        }
        if (start)
        {
            SceneManager.LoadScene("MasterLevel2");
            BoltNetwork.LoadScene("MasterLevel2");
        }
    }
    public void enterBuffer(GameObject player)
    {
            bufferPlayers.Add(player);
            bufferState = true;

    }
}
