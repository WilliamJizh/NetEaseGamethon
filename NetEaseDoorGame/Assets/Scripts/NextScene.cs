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
        portaloff = transform.GetChild(1).GetChild(0).gameObject;
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
    private void OnTriggerEnter(Collider other)
    {
        if(!doorlock) BRM.enterBuffer(other.gameObject);
        var finaldoor = FinalDoorPassed.Create(entity);
        finaldoor.Send();
    }

    public void SetDoorUnlock() {
        var dooropen = DoorOpen.Create(entity);
        dooropen.Send();
    }

    public override void OnEvent(DoorOpen evnt)
    {
        doorlock = false;
    }
    public override void OnEvent(FinalDoorPassed evnt)
    {
        maxplayernum--;
        if (maxplayernum <= 0) doorlock = true;
    }
}
