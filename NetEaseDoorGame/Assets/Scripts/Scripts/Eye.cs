using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : ItemClass
{

    public GameObject player;
    private BasicRangeAttack basicRangeAttack;
    private BasicProjectile basicProjectile;
    void Awake()
    {
        basicRangeAttack = player.GetComponent<BasicRangeAttack>();
        basicProjectile = basicRangeAttack.projectileprefeb.GetComponent<BasicProjectile>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetIcon();
        Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            IncreaseAttackRange();
            //If player collected eye, then set the boolean logic to false.
            collected = false;
        }
    }

    //increase player's attack range after collecting eye item
    void IncreaseAttackRange()
    {
        basicProjectile.timeModifier += 0.3f;
    }
}
