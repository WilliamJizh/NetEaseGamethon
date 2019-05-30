using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : MonoBehaviour
{
    [SerializeField]
    string names;
    [SerializeField]
   public  Sprite icon;

    public void SetIcon()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
    }
    public void SetIcon(Sprite spt)
    {
        this.GetComponent<SpriteRenderer>().sprite = spt;
    }
    public Sprite GetIcon()
    {
        return icon;
    }
    public void Collect()
    {
        this.gameObject.AddComponent<BoxCollider>();
        this.gameObject.GetComponent<BoxCollider>().size= new Vector3(1, 1, 1);
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<ItemMananger>().RecieveItem(this);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
    }

}