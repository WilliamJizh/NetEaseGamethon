using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosFollow : MonoBehaviour
{
    [SerializeField]
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
            print("player.transform.position.z: "+ player.transform.position.z);
            print(" camerapos.z: " + camerapos.z);
            camerapos.y = height;
            transform.position = camerapos;
            print("transform.position.z: "+transform.position.z);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void GetPlayer(GameObject player) {

        this.player = player;
       
    }
}
