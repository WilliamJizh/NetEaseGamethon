using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUIControl : MonoBehaviour
{
    Image Image;
    DoorManager dm;
    float doorlocktime;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        dm = transform.parent.gameObject.transform.parent.gameObject.GetComponent<DoorManager>();
        doorlocktime = dm.doorlocktime;
    }

    // Update is called once per frame
    void Update()
    {
        Image.fillAmount =  (dm.timer / doorlocktime);
        
    }
}
