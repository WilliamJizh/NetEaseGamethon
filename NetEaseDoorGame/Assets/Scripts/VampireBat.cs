using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireBat : ItemClass
{
    // Start is called before the first frame update
    void Start()
    {
        names = "吸血蝙蝠";
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
