using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligators : FloatingMovers
{
    public Animation anim;
    public int willGatorDive;
    private float startDelay = 10;
    private float checkInterval = 5f;

    void Start()
    {
        base.Move();
        anim = gameObject.GetComponent<Animation>();
        InvokeRepeating("AlligatorDiving", startDelay, checkInterval);
    }
    //override ontriggerenter to start alligator diving instead of invoke repeating
    void AlligatorDiving()
    {
        willGatorDive = Random.Range(0, 100);
        if (willGatorDive == 50)
        {
            anim.Play("DivingGator");
        }
    }
}
