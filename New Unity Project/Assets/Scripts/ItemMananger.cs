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
        imagePos = new Vector2(150, 500);
        cv = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {
        if (refresh)
        {
            if (items.Capacity > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    GameObject img = new GameObject();
                    var icon = img.AddComponent(typeof(Image));
                    icon.GetComponent<Image>().sprite = items[i].icon;

                    //让图标的位置并排列开

                    Instantiate(icon, imagePos, Quaternion.identity, cv);
                    if(i ==items.Count-1)
                    {
                        refresh = false;
                    }

                }
=======
    {
        if (refresh)
        {
            if (items.Capacity > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    GameObject img = new GameObject();
                    var icon = img.AddComponent(typeof(Image));
                    icon.GetComponent<Image>().sprite = items[i].icon;


                    Instantiate(icon, imagePos, Quaternion.identity, cv);
                    if(i ==items.Count-1)
                    {
                        refresh = false;
                    }

                }
>>>>>>> 9e3a0a52a70970f6747f4a96b897d700cd03bd49
            }
        }
    }

    public void ReceiveItem(ItemClass item) 
    {

        refresh=true;
        items.Add(item);
       
    }
}
