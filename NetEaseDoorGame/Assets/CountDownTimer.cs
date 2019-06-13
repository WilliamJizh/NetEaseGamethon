using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    Text countdowntext;
    GameObject exitr;
    GameObject exitb;
    GameManager gm;

    [SerializeField]
    Color exitcolor;
    // Start is called before the first frame update
    void Start()
    {
        countdowntext = GetComponent<Text>();
        exitr = transform.GetChild(0).gameObject;
        exitb = transform.GetChild(1).gameObject;
        gm = GameObject.Find("GameStateManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gm.gamestate)
        {
            case GameState.Ready:
                WaitingPlayer();
                break;

            default:
                CountDown();
                break;
        }
    }

    void WaitingPlayer() {
        countdowntext.text = gm.playernum.ToString() + " of " + gm.maxplayer;
    }

    void CountDown()
    {
        if (!gm.finaldoorlock) {
            exitr.SetActive(false);
            exitb.SetActive(true);
        }

        if (gm.countdowntimer >= 0)
        {
            int countdown = (int)gm.countdowntimer;
            countdowntext.text = countdown.ToString();
        }

    }


}
