using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Alligators : FloatingMovers
{
    public int willGatorDive;
    private float startDelay = 10;
    private float checkInterval = 5f;
    public PlayableDirector playableDirector;

    void Start()
    {
        base.Move();
        InvokeRepeating("AlligatorDiving", startDelay, checkInterval);
    }
    //override ontriggerenter to start alligator diving instead of invoke repeating
    void AlligatorDiving()
    {
        willGatorDive = Random.Range(0, 10);
        if (willGatorDive == 5)
        {
            Play();
        }
    }
    public void Play()
    {
        playableDirector.Play();
        Debug.Log("alligator dives");
    }
}
