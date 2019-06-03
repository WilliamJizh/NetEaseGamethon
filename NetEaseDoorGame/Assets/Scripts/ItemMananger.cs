using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMananger : MonoBehaviour
{
  public  List<ItemClass> items;
    public Transform cv;
     Vector2 imagePos;
    bool refresh;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<ItemClass> ();
        imagePos = new Vector2(0, 0);
        cv = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (refresh)
        {
            if (items.Capacity > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    GameObject img = new GameObject();
                    var icon = img.AddComponent(typeof(Image));
                    img.GetComponent<Image>().sprite = items[i].icon;
                    //让图标的位置并排列开
                    Instantiate(img, imagePos, Quaternion.identity, cv);
                   


                    if(i ==items.Count-1)
                    {
                        refresh = false;
                    }

                }
            }
        }
    }

    public void ReceiveItem(ItemClass item) 
    {

        refresh=true;
        items.Add(item);
       
    }
}
