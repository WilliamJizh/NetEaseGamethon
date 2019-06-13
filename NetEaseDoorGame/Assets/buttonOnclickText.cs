using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonOnclickText : MonoBehaviour
{
  
    public void showText()
    {
        this.transform.parent.gameObject.GetComponentInChildren<Text>().enabled = true;
    }
    public void noShowText()
    {
        this.transform.parent.gameObject.GetComponentInChildren<Text>().enabled = false;
    }
}
