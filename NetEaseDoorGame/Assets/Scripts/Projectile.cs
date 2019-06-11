using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

    PlayerStats playerstat;
    public PlayerStats targetstat;

    float dmg;
    string effect;
    float size;
    public bool successfulhit = false;
    

    //set a timer to control the fire range
    public float existtime = 0.5f;

    public void  SetShooter(GameObject shooter) {
        playerstat = shooter.GetComponent<PlayerStats>();
        dmg = playerstat.dmg;
        effect = playerstat.attackeffect;
        speed = playerstat.projectileSpeed;
        size = playerstat.projectileSize;
        Debug.Log(size);
        transform.localScale = new Vector3(size, size, size);
        StartCoroutine(OutOfRange());
    }


    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
      


    }
    // Projectile destroy timer
    IEnumerator OutOfRange() {
            yield return new WaitForSecondsRealtime(playerstat.existtime);
            Destroy(this.gameObject);

         }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player" && collision.gameObject != playerstat.gameObject)
        {
            if (collision.gameObject.GetComponent<PlayerStats>().currState == PlayerState.Roll) return;
            collision.gameObject.GetComponent<PlayerStats>().Hitreaction(dmg, effect);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<AiStates>().Hitreaction(dmg, effect);
        }


        Destroy(this.gameObject);
    }


    /*private void OnTriggerEnter(Collider other)    {

        PlayerStats targetstat = null;
        if (other.gameObject.tag == "player") {
            targetstat = other.gameObject.GetComponent<PlayerStats>();
        }
        if (targetstat != null) {
            Debug.Log("Hit sent");
            successfulhit = true;
            targetstat.Hitreaction(playerstat.dmg, playerstat.attackeffect);
            successfulhit = false;
        }
        

        

    }*/
    



}
