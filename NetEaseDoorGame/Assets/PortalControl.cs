using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    GameObject on;
    GameObject closed;
    DoorManager dm;
    // Start is called before the first frame update
    void Start()
    {
        dm = transform.parent.gameObject.transform.parent.gameObject.GetComponent<DoorManager>();
        closed = transform.GetChild(0).gameObject;
        on = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        closed.SetActive(dm.doorlock);
        on.SetActive(!dm.doorlock);
        
    }
}
