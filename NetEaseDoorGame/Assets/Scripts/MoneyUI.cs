using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    Text money;
    PlayerStats playerstat;
    // Start is called before the first frame update
    void Start()
    {
        money = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(playerstat!=null)
        money.text = playerstat.money.ToString();
    }

    public void SetPlayer(PlayerStats player) {
        playerstat = player;
    }
}
