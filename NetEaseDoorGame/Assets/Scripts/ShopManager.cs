using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public float price;

    [SerializeField]
    GameObject item;

    [SerializeField]
    float offset;
    [SerializeField]
    Sprite displayicon;

    GameObject plane;
    // Start is called before the first frame update

    void Start()
    {
        displayicon = item.GetComponent<SpriteRenderer>().sprite;        
        
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Buy");
                
                PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
               if (player.money >= price)
                {
                    player.money -= price;
                    Instantiate(item, transform.position + transform.forward * offset, Quaternion.identity);

                }
            }
        }
    }

}
