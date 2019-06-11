using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIstate
{
    Wander,
    Chase,
    Attack,
    OnHit,

}

public class AiStates : Bolt.EntityBehaviour<IEnemyState>
{
    

    AIstate aistate = AIstate.Wander;
    CharacterController aicontroller;

   
    GameObject[] players;
    [SerializeField]
    GameObject currtarget;

    [SerializeField]
    int dropamount;
 
    public float threatmodifier = 1;

    [SerializeField]
    float alertrange;
    [SerializeField]
    float attackdistance ;
    [SerializeField]
    float speed;
    [SerializeField]
    float burstspeed;

    float currspeed;


    [SerializeField]
    float attackactionlast = 1;

    
    public Vector3 spawnposition = Vector2.zero;


    [SerializeField]
    float health = 10;

    [SerializeField]
    float dmg = 5;
    [SerializeField]
    string effect = "None";

    [SerializeField]
    float onhitstun = 0.3f;

    

    [SerializeField]
    float attackinterval = 3;
    float nextburst = 0;

    [SerializeField]
    GameObject bloodprefab;
    [SerializeField]
    GameObject moneyprefab;

    // Start is called before the first frame update
    public override void Attached()
    {
        aicontroller = GetComponent<CharacterController>();
        alertrange *= threatmodifier;
        speed *= threatmodifier;
        transform.localScale *= threatmodifier;
        health *= threatmodifier ;
        dropamount = (int)Mathf.Ceil((float)dropamount* threatmodifier) ;

        currspeed = speed;
        state.SetTransforms(state.EnemyTransform, transform);

    }



    public override void SimulateOwner()
    {
        
    }

    void Update()
    {
        
        switch (aistate) {
            case AIstate.Wander:
                Wandering();
                break;
            case AIstate.Chase:
                Chase();
                break;
            case AIstate.Attack:
                Attack();
                break;

        }
    }

    void Wandering() {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (Vector3.Distance(transform.position, spawnposition) > alertrange/3)
        {
            
            Movement(spawnposition);
        }

        EnemySearch();
        
    }


    void EnemySearch() {
        float mindis = 50;
        foreach (GameObject target in players) {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < alertrange && distance < mindis) {
                mindis = distance;
                currtarget = target;
                aistate = AIstate.Chase;
                
            }
        }

    }


    void Chase() {
        if (currtarget != null)
        {
            float distance = Vector3.Distance(currtarget.transform.position, transform.position);
            if (distance > alertrange) {
                aistate = AIstate.Wander;
                
            }
            
            if (distance < attackdistance && Time.time> nextburst) aistate = AIstate.Attack;
            else Movement(currtarget.transform.position);
        }

        else aistate = AIstate.Wander;

        


    }


    void Movement(Vector3 targetpos) {

        targetpos.y = transform.position.y;
        //aicontroller.Move(Vector3.forward * currspeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetpos, currspeed * Time.deltaTime);
      
     
       
        transform.LookAt(targetpos);
    }


    void Attack() {
        Debug.Log("Burst!");

        // attack action
        currspeed = burstspeed;
        Movement(currtarget.transform.position);
        
        StartCoroutine(Attacklast());
    }

    IEnumerator Attacklast()
    {
        yield return new WaitForSeconds(attackactionlast);
        currspeed = speed;
        nextburst = Time.time + attackinterval;
        EnemySearch();

    }

    public void Hitreaction(float dmg, string effect) {
        Debug.Log("Enemy hit " + dmg);
        health -= dmg;
        aistate = AIstate.OnHit;
        StartCoroutine(HitRecover());
        if (health <= 0 && BoltNetwork.IsServer) {
            Drop();
            Debug.Log("Enemy Down");
            BoltNetwork.Destroy(this.gameObject);
            
        }
        


    }

    IEnumerator HitRecover() {
        yield return new WaitForSeconds(onhitstun);
        aistate = AIstate.Attack;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().Hitreaction(dmg, effect);
            nextburst = Time.time + attackinterval;
        }
    }

    void Drop() {
        int Droprandom =  Random.Range(0, 5);
        if (Droprandom == 0)
        {
            DropBlood();
        }
        DropMoney();
    }

    void DropBlood() {
        Instantiate(bloodprefab, transform.position, Quaternion.identity).GetComponent<BloodFire>().bloodamount = dropamount; 
    }

    void DropMoney() {
        Instantiate(moneyprefab, transform.position, Quaternion.identity).GetComponent<SoulFire>().moneyamount = dropamount;
    }
}
