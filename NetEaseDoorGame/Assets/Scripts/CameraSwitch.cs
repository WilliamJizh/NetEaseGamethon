using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    bool cameraOn;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.transform.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraOn == true)
        {
            camera.enabled = true;
        }
        else
        {
            camera.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraOn = true;
        }
        else
        {
            cameraOn = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraOn = false;
        }
    }

}
