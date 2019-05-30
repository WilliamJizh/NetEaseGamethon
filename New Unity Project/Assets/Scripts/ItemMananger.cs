using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMananger : MonoBehaviour
{
    List<ItemClass> items;
    // Start is called before the first frame update
    void Start()
    {
        List<ItemClass> items = new List<ItemClass> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveItem(ItemClass item) 
    {
        items.Add(item);
    }
}
