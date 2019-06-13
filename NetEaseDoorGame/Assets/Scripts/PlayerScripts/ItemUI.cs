using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemUI : Bolt.EntityBehaviour
{
    public ItemMananger itemMan;
    public GameObject cv;
    public GameObject itemIconUIholder;
    public Object textPrefab;
    public Object button;
    Vector3 imagePos;
    float width;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        if (!entity.IsOwner) return;
        itemMan = GetComponent<ItemMananger>();
        cv = GameObject.Find("Canvas");
        itemIconUIholder = GameObject.Find("ItemIcons");
       
        imagePos = new Vector3(-580,380,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //在屏幕上显示技能图标

    public void displayUI(List<ItemClass> items)
    {
        if (!entity.IsOwner) return;
        if (itemIconUIholder.GetComponent<RectTransform>() != null) {
            foreach (RectTransform child in itemIconUIholder.GetComponent<RectTransform>())
            {
                Destroy(child.gameObject);
            }
        }


        //itemUI.displayUI();
        for (int i = 0; i < items.Count; i++)
            {
         
                GameObject img = new GameObject();
                var icon = img.AddComponent(typeof(Image));
                img.GetComponent<Image>().sprite = items[i].icon;
                //让图标的位置并排列开
                GameObject iconUI = Instantiate(img, imagePos, Quaternion.identity, itemIconUIholder.GetComponent<RectTransform>());
                imagePos = new Vector3(-800+ i * 100, 330, 0);
                iconUI.GetComponent<RectTransform>().localPosition = imagePos;
                Destroy(img);
                GameObject buttons= (GameObject)Instantiate(button, imagePos, Quaternion.identity, iconUI.GetComponent<RectTransform>());
                buttons.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                GameObject discription =(GameObject) Instantiate(textPrefab, imagePos, Quaternion.identity, iconUI.GetComponent<RectTransform>());
                discription.GetComponent<RectTransform>().localPosition = new Vector3(200,-200,0);
                discription.GetComponent<Text>().text = items[i].discription;

            if (i == items.Count - 1)
                {
                   itemMan.refresh = false;
                }

            }
        }

    

}
