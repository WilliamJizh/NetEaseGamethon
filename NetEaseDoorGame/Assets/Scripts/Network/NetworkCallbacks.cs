using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    Vector3 spawnPosition = new Vector3(Random.Range(-1, 1), 10, Random.Range(-1, 1));
    public override void SceneLoadLocalDone(string map)
    {        
        PlayerSpawn();
        EnemySpawn();
        
    }

    void PlayerSpawn() {
        Debug.Log("instantiate player");
        BoltNetwork.Instantiate(BoltPrefabs.Player, spawnPosition, Quaternion.identity);
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
