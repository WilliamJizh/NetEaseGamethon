using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Bolt.EntityEventListener
{

    public float price;

    [SerializeField]
    GameObject item;

    [SerializeField]
    float offset;
    [SerializeField]
    Sprite displayicon;

    
    SpriteRenderer planetexture;
    // Start is called before the first frame update

    string interactionbutton = "Fire3";
    void Start()
    {
        displayicon = item.GetComponent<SpriteRenderer>().sprite;
        planetexture = transform.GetChild(0).GetComponent<SpriteRenderer>();
        planetexture.sprite = displayicon;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        //check if it's player or not, and is the doo unlocked, and press E to teleport;
        if (other.gameObject.tag == "Player")
        {

            if (Input.GetButtonDown(interactionbutton))
            {
                Debug.Log("Buy");

                PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
                if (player.money >= price)
                {
                    player.money -= price;
                    var storepurchase = StorePurchase.Create(entity);
                    storepurchase.Send();

                }
            }
        }
    }


    public override void OnEvent(StorePurchase evnt)
    {
        Instantiate(item, transform.position + transform.forward * offset, Quaternion.identity);
    }

}
