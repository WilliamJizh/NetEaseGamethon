using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : MonoBehaviour
{
    [SerializeField]
    public string names;
    [SerializeField]
    //2D sprite for icon
    public  Sprite icon;
    // bool for collected or not
    public bool collected = false;
    //player gameobject
    private GameObject playerObject;

    //set the icon for item
    public void SetIcon()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
    }

    //get the sprite of the icon
    public Sprite GetIcon()
    {
        return icon;
    }

    //give the item a box collider 
    public void Collect()
    {
        this.gameObject.AddComponent<BoxCollider>();
        this.gameObject.GetComponent<BoxCollider>().size= new Vector3(1, 1, 1);
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
    //return the player object
    public GameObject getPlayer()
    {
        return playerObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerObject = other.gameObject;
            collected = true;
            other.GetComponent<ItemMananger>().ReceiveItem(this);

            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

}