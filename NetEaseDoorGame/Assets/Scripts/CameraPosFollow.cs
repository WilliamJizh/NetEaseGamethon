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
        DontDestroyOnLoad(this.gameObject);
    }

    public void GetPlayer(GameObject player) {

        this.player = player;
       
    }
}
