using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Bolt.EntityEventListener
{
    [SerializeField]
    float offset = 1;

    string interatcionbutton = "Fire3";

    ItemDropManager itemmanager;

    Vector3 itemspawnpos;

    bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        itemmanager = GameObject.Find("DropManager").GetComponent<ItemDropManager>();
        itemspawnpos = transform.position + Vector3.back * offset;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (Input.GetButtonDown(interatcionbutton) && opened == false)
            {
                var chestopen = ChestOpen.Create(entity);
                chestopen.Itemid = itemmanager.RandomDrop();
                chestopen.Send();

            }
        }
    }


    public override void OnEvent(ChestOpen evnt)
    {
        itemmanager.ItemSpawn((int)evnt.Itemid, itemspawnpos);
        opened = true;
    }
}
