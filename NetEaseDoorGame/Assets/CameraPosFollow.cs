using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosFollow : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {

            Vector3 camerapos = transform.position;
            camerapos.x = player.transform.position.x;
            camerapos.z = player.transform.position.z;
            
            transform.position = camerapos;
        }
    }

    public void GetPlayer(GameObject player) {

        this.player = player;
       
    }
}
