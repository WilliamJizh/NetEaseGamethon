using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggItem : ItemClass
{

    // Start is called before the first frame update
    void Start()
    {
        //如果要从文件读取sprite
        //使用 SetIcon(路径/“文件名”)；

        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
 
    }

   // public void OnTriggerEnter(Collider other);
}
