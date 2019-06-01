using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetworkCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string map)
    {
        // randomize a position
        var spawnPosition = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        // instantiate cube
        BoltNetwork.Instantiate(BoltPrefabs.Player, spawnPosition, Quaternion.identity);
    }
}
