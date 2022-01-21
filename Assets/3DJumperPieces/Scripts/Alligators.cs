using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Alligators : FloatingMovers
{
    //INHERITANCE from FloatingMovers
    public int willGatorDive;
    private float startDelay = 10;
    private float checkInterval = 5f;
    private float speed = 4f;

    void Start()
    {
        InvokeRepeating("AlligatorDiving", startDelay, checkInterval);
    }
    void Update()
    {
        Move();
    }
    //override ontriggerenter to start alligator diving instead of invoke repeating
    public void AlligatorDiving()
    {
        willGatorDive = Random.Range(0, 10);

    }
    //POLYMORHISM overriding Move() method from FloatingMovers
    public override void Move()
    {
        if (willGatorDive == 5)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            Debug.Log("alligator dives");
        }
        else
        {
            base.Move();
        }
    }
}
