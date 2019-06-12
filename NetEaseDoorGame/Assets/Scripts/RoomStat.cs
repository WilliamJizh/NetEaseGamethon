using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStat : MonoBehaviour
{
    [SerializeField]
    float roomnum;

    [SerializeField]
    Vector3 camerapos;

    // Start is called before the first frame update
    void Start()
    {
        camerapos = gameObject.transform.Find("MainCameraPos").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
