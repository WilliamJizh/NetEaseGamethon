using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPosManager : MonoBehaviour
{

    [SerializeField]
    Vector3[] SpawnPos;
    int Playernum = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = new Vector3[20];

        GameObject[] playerspawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        for (int i = 0; i <= playerspawns.Length; i++) {
            Debug.Log("Spawnpos added");
            SpawnPos[i] = playerspawns[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetSpawnPos() {
        Playernum++;
        return SpawnPos[Playernum];
    }

}
