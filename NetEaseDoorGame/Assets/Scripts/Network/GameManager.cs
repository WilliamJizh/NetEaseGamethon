using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState {
    Ready,
    Starting,
    ZoningCountDown,
    Zoning,
    
 }

public class GameManager : Bolt.GlobalEventListener
{
    public GameState gamestate;

    GameObject[] playerlist;

    GameObject[] normdoorlist;

    GameObject[] enemyspawns;

    GameObject[] finaldoors;

   
    public int maxplayer;

    [SerializeField]
    float dooropentimer = 5;

    [SerializeField]
    float zoningtimer = 10;

    [SerializeField]
    float finaldoortimer = 200;


    [SerializeField]
    float enemyspawninterval = 30;

    public float countdowntimer;
    public int playernum;
    public bool finaldoorlock = true;

    // Start is called before the first frame update
    void Start()
    {
        normdoorlist = GameObject.FindGameObjectsWithTag("NormDoor");
        enemyspawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        finaldoors = GameObject.FindGameObjectsWithTag("FinalDoor");
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(gamestate);
        switch (gamestate) {
            case GameState.Ready:
                UpdatePlayer();
                break;
            case GameState.Starting:
                GlobalDoorOpener();
                break;
            case GameState.ZoningCountDown:
                ZoningCountDown();
                break;

            case GameState.Zoning:
                Zoning();
                break;
            
            

        }
        
    }

    void UpdatePlayer() {
        playerlist = GameObject.FindGameObjectsWithTag("Player");
        playernum = playerlist.Length;
        if (playernum >= maxplayer) {
            countdowntimer = dooropentimer;
            gamestate = GameState.Starting;

        }
    }

    void UnlockDoor()
    {
        foreach (GameObject door in normdoorlist)
        {
            door.GetComponent<DoorManager>().GloabalUnlock();
        }
        
    }

    void GlobalDoorOpener() {
        
        if (countdowntimer <= 0)
        {
            if (BoltNetwork.IsServer) {
                UnlockDoor();
            }
            StartCoroutine(FinalDoorTimer());
            countdowntimer = zoningtimer;
            gamestate = GameState.ZoningCountDown;
        }
        else CountDownTimer();

    }


    void CountDownTimer() {
        if (countdowntimer > 0) {

            countdowntimer -= Time.deltaTime;
        }
    }

    void ZoningCountDown() {

        if (countdowntimer <= 0)
        {
            gamestate = GameState.Zoning;
        }
        else CountDownTimer();
    }

    void Zoning() {
        
        if (countdowntimer <= 0) {
            EnemySpawn();
            countdowntimer = enemyspawninterval;
        }
        CountDownTimer();
    }


    // Enemy Spawn Manager
    void EnemySpawn()
    {
        if (!BoltNetwork.IsServer) return;
        foreach (GameObject es in enemyspawns)
        {
            EnemySpawn e = es.GetComponent<EnemySpawn>();
            e.Spawn();
        }
    }


    IEnumerator FinalDoorTimer() {
        yield return new WaitForSeconds(finaldoortimer);
        finaldoorlock = false;
        
        foreach (GameObject fd in finaldoors) {
            if (!BoltNetwork.IsServer) break;
            //unlock final door
        }
    }
}
