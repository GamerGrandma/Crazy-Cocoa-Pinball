using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : FloatingMovers
{
    void Start()
    {
        //base.Move();
    }

    //Do logs need to do something different?
    void FixedUpdate()
    {
        base.Move();
    }
}
