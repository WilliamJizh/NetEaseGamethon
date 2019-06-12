using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosFollow : MonoBehaviour
{

    GameObject player;
    [SerializeField]
    float height;
    // Start is called before the first frame update
    void Start()
    {
        height = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {

            Vector3 camerapos = transform.position;
            camerapos.x = player.transform.position.x;
            camerapos.z = player.transform.position.z;
            camerapos.y = height;
            transform.position = camerapos;
        }
    }

    public void GetPlayer(GameObject player) {

        this.player = player;
       
    }
}
