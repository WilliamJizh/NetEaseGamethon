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
        // width = cv.GetComponent<RectTransform>().rect.width;
        // height = cv.GetComponent<RectTransform>().rect.height;
        //   print(width/2);
        //  print(height/5);

        // cv= SceneManager.GetActiveScene().
        imagePos = new Vector3(-620,400,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //在屏幕上显示技能图标

    public void displayUI(List<ItemClass> items)
    {
        foreach (RectTransform child in itemIconUIholder.GetComponent<RectTransform>())
        {
            Destroy(child.gameObject);
        }

        //itemUI.displayUI();
        for (int i = 0; i < items.Count; i++)
            {
         

            GameObject img = new GameObject();
                var icon = img.AddComponent(typeof(Image));
                img.GetComponent<Image>().sprite = items[i].icon;
                //让图标的位置并排列开
                GameObject iconUI = Instantiate(img, imagePos, Quaternion.identity, itemIconUIholder.GetComponent<RectTransform>());
                imagePos = new Vector3(-620+ i * 100, 400, 0);
                iconUI.GetComponent<RectTransform>().localPosition = imagePos;
                Destroy(img);


                if (i == items.Count - 1)
                {
                   itemMan.refresh = false;
                }

            }
        }

}
