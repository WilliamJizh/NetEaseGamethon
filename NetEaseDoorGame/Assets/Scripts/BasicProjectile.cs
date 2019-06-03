using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField]
    float speed = 30;

    PlayerStats playerstat;

    float dmg;
    string effect;

    //set a timer to control the fire range
    public float existtime = 0.5f;

    public void  SetShooter(GameObject shooter) {
        playerstat = shooter.GetComponent<PlayerStats>();
        dmg = playerstat.dmg;
        effect = playerstat.attackeffect;
    }


    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Projectile destroy timer
        StartCoroutine(OutOfRange());
    }

        IEnumerator OutOfRange() {
            yield return new WaitForSecondsRealtime(existtime);
            Destroy(this.gameObject);

        
    }

    void OnTriggerEnter(Collider other)    {

        /*PlayerStats targetstat = null;
        if (other.gameObject.tag == "player") {
            targetstat = other.gameObject.GetComponent<PlayerStats>();
        }
        if (targetstat != null) {
            Debug.Log("Hit sent");
            targetstat.Hitreaction(playerstat.dmg, playerstat.attackeffect);
        }
        */

        Debug.Log(other.gameObject.name);

        other.gameObject.GetComponent<PlayerStats>().Hitreaction(dmg,effect);

    }
    



}
