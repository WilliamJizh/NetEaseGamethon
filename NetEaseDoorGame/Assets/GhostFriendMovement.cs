using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFriendMovement : MonoBehaviour
{
    public GameObject littleFriend;
    public GameObject followTarget;
    float friendPos;
    Vector3 ftPos;
    Vector3 spawnPos;
    Vector3 lfPos;

   
    // Start is called before the first frame update
    void Start()
    {
        ftPos = followTarget.transform.position;
        lfPos = followTarget.transform.position;

        spawnPos = new Vector3(ftPos.x -(ftPos.x - lfPos.x),
                               ftPos.y - (ftPos.y - lfPos.y), 
                               ftPos.z - (ftPos.z - lfPos.z));

        Instantiate(littleFriend, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
