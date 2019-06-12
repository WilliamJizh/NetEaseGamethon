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
        if (items.Count >= 0)
        {
            if (refresh)
            {


                itemUI.displayUI(items);
               

            }
        }
    }

    public void ReceiveItem(ItemClass item) 
    {

        items.Add(item);

        refresh = true;

    }
    public void RemoveItem(string name )
    {

        for(int i = 0; i < items.Count; i++)
        {
            print(i);
            print(items[i].names);

            if (items[i].names.Equals(name))
            {
                items.RemoveAt(i);
            }
        }
        refresh = true;
    }
}
