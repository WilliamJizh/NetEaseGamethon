using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    Vector3 spawnPosition;
    Vector3[] spawnpos;
    int playernum = 0;
    GameObject[] playerlist;

    public override void SceneLoadLocalDone(string map)
    {
       
        spawnpos = new Vector3[20];

        GameObject[] playerspawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        for (int i = 0; i < playerspawns.Length; i++)
        {
            Debug.Log("Spawnpos added");
            spawnpos[i] = playerspawns[i].transform.position;
        }
        UpdatePlayerNum();
        PlayerSpawn();
        EnemySpawn();
        
    }

    void UpdatePlayerNum() {
        playerlist =  GameObject.FindGameObjectsWithTag("Player");
        playernum = playerlist.Length;
        Debug.Log(playernum);
    }

    void PlayerSpawn() {
        Debug.Log("instantiate player");
        BoltNetwork.Instantiate(BoltPrefabs.Player, spawnpos[playernum], Quaternion.identity);
        GameObject.Find("Network").SetActive(false);
    }

    // Enemy Spawn Manager
    void EnemySpawn() {
        // Only server spawn enemies
        if (!BoltNetwork.IsServer) return;
        //Find all enemyspawn points and spawn on them
        GameObject[] enemyspawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        foreach (GameObject es in enemyspawns)
        {
            EnemySpawn e = es.GetComponent<EnemySpawn>();
            e.Spawn();
        }
    }
}
