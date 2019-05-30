using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : MonoBehaviour
{
    [SerializeField]
    string names;
    [SerializeField]
    Sprite icon;

    public void SetIcon()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
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
            other.GetComponent<ItemMananger>().recieveItem(this);
            this.gameObject.SetActive(false);
        }
    }

}