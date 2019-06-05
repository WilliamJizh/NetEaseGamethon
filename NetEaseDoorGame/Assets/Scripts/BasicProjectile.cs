using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

    PlayerStats playerstat;
    public PlayerStats targetstat;

    float dmg;
    string effect;
    public bool successfulhit = false;

    //set a timer to control the fire range
    public float existtime = 0.5f;

    public void  SetShooter(GameObject shooter) {
        playerstat = shooter.GetComponent<PlayerStats>();
        dmg = playerstat.dmg;
        effect = playerstat.attackeffect;
        playerstat.newProjectileSpeed = speed;
    }


    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Projectile destroy timer
        StartCoroutine(OutOfRange());
    }

        IEnumerator OutOfRange() {
            yield return new WaitForSecondsRealtime(playerstat.existtime);
            Destroy(this.gameObject);

         }

    void OnTriggerEnter(Collider other)    {

        /*PlayerStats targetstat = null;
        if (other.gameObject.tag == "player") {
            targetstat = other.gameObject.GetComponent<PlayerStats>();
        }
        if (targetstat != null) {
            Debug.Log("Hit sent");
            successfulhit = true;
            targetstat.Hitreaction(playerstat.dmg, playerstat.attackeffect);
            successfulhit = false;
        }
        */

        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "player")  other.gameObject.GetComponent<PlayerStats>().Hitreaction(dmg,effect);

    }
    



}
