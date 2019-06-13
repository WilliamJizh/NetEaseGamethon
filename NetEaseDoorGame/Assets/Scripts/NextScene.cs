using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : Bolt.EntityEventListener
{
    public bool doorlock = true;
    public BufferRoomManager BRM;
    GameObject portalon;
    GameObject portaloff;

    [SerializeField]
    int maxplayernum = 2;
    // Start is called before the first frame update
    void Start()
    {
        BRM = GameObject.Find("BufferRoomManager").GetComponent<BufferRoomManager>();
        portaloff = transform.GetChild(1).GetChild(1).gameObject;
        portalon = transform.GetChild(1).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorlock) {
            portaloff.SetActive(true);
            portalon.SetActive(false);
        }
        if (!doorlock)
        {
            portaloff.SetActive(false);
            portalon.SetActive(true);
        }
    }
    

    public void SetDoorUnlock() {
        var dooropen = DoorOpen.Create(entity);
        dooropen.Send();
    }

    public override void OnEvent(DoorOpen evnt)
    {
        Debug.Log("unlock");
        doorlock = false;
    }
  
}
