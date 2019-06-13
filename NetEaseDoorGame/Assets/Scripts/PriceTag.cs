using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceTag : MonoBehaviour
{
    Text pricetag;
    float price;
    ShopManager shopmanager;
    // Start is called before the first frame update
    void Start()
    {
        shopmanager = transform.parent.gameObject.transform.parent.GetComponent<ShopManager>();
        price = shopmanager.price;
        pricetag = GetComponent<Text>();
        pricetag.text = price.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
