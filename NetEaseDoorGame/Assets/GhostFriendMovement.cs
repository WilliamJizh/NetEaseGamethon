using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFriendMovement : MonoBehaviour
{
    public GameObject littleFriendPrefab;
    public GameObject followTarget;
    public GameObject littleFriend;
   
    float friendPos;
    float followSpeed;

    Transform ftPos;
    Vector3 spawnPos;
    Transform lfPos;

   
    // Start is called before the first frame update
    void Start()
    {
        ftPos = followTarget.transform;

        spawnPos = new Vector3(ftPos.position.x - 2f,
                               ftPos.position.y, 
                               ftPos.position.z - 2f) ;

       littleFriend = Instantiate(littleFriendPrefab, spawnPos, Quaternion.identity);
       
       lfPos = littleFriend.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        Movenemt();

    }

    void Movenemt()
    {
       
        followSpeed = 5f;

        lfPos.LookAt(followTarget.transform);
        lfPos.position = Vector3.MoveTowards(lfPos.position,
                                    ftPos.position,
                                    followSpeed * Time.deltaTime);
        Debug.Log(lfPos);
    }
}
