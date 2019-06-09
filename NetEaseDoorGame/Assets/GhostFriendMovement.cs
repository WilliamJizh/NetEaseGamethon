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
    float distance;


    Transform ftTran;
    Transform lfTran;

    Vector3 spawnPos;





    // Start is called before the first frame update
    void Start()
    {
        ftTran = followTarget.transform;

        spawnPos = new Vector3(ftTran.position.x - 2f,
                               ftTran.position.y, 
                               ftTran.position.z - 2f) ;

       littleFriend = Instantiate(littleFriendPrefab, spawnPos, Quaternion.identity);
       
       lfTran = littleFriend.transform;

 

       
    }

    // Update is called once per frame
    void Update()
    {
       
        Movenemt();

    }

    void Movenemt()
    {

       
        followSpeed = 3f;
        distance = 2f;

        lfTran.LookAt(followTarget.transform);
        //lfTran.position = Vector3.MoveTowards(lfTran.position,
                                                 //ftTran.position,
                                                 //followSpeed * Time.deltaTime);


        if (ftTran.position.x > lfTran.position.x && ftTran.position.z > lfTran.position.z)
        {
            lfTran.position = Vector3.MoveTowards(lfTran.position,
                                      new Vector3(ftTran.position.x + distance, ftTran.position.y, ftTran.position.z + distance ),
                                                  followSpeed * Time.deltaTime);
        }
        if (ftTran.position.x < lfTran.position.x && ftTran.position.z < lfTran.position.z)
        {
            lfTran.position = Vector3.MoveTowards(lfTran.position,
                                      new Vector3(ftTran.position.x - distance, ftTran.position.y, ftTran.position.z - distance),
                                                  followSpeed * Time.deltaTime);
        }
        if (ftTran.position.x > lfTran.position.x && ftTran.position.z < lfTran.position.z)
        {
            lfTran.position = Vector3.MoveTowards(lfTran.position,
                                      new Vector3(ftTran.position.x - distance, ftTran.position.y, ftTran.position.z + distance),
                                                  followSpeed * Time.deltaTime);
        }
        if (ftTran.position.x < lfTran.position.x && ftTran.position.z > lfTran.position.z)
        {
            lfTran.position = Vector3.MoveTowards(lfTran.position,
                                      new Vector3(ftTran.position.x + distance, ftTran.position.y, ftTran.position.z - distance),
                                                  followSpeed * Time.deltaTime);
        }







    }

}
