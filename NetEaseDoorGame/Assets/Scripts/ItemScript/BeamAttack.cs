using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : ItemClass
{
    public GameObject player;
    private PlayerStats characterMovement;
    private ItemMananger itemMananger;



    // Start is called before the first frame update
    void Start()
    {
        names = "激光镜";
        SetIcon();
        Collect();

    }

    // Update is called once per frame
    void Update()
    {
        if (collected == true)
        {
            setPlayer();
            CheckBarrier();
        }
    }

    void setPlayer()
    {

        player = getPlayer();
        
     

    }
        void CheckBarrier()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        /*if (Physics.Raycast(transform.position, fwd, out hit, 1))
            Debug.DrawLine(transform.position, hit.point, Color.red);*/

    }
}
