using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMananger : MonoBehaviour
{
    ItemUI itemUI;
    public  List<ItemClass> items;

   public bool refresh;


    // Start is called before the first frame update
    void Start()
    {
        itemUI = GetComponent<ItemUI>();
        items = new List<ItemClass> ();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (items.Capacity > 0)
        {
            if (refresh)
            {

                itemUI.displayUI(items);


            }
        }
    }

    public void ReceiveItem(ItemClass item) 
    {

        refresh=true;
        items.Add(item);
       
    }
}
