using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballMover : MonoBehaviour
{
    public Collider pinballColl;
    public GameObject holdBall;
    void Start()
    {
        pinballColl = GetComponent<Collider>();
        holdBall.SetActive(true);
    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hold Ball"))
        {
            pinballColl.attachedRigidbody.useGravity = false;
            pinballColl.transform.position = other.transform.position;
        }
        if (other.gameObject.CompareTag("Shooter"))
        {
            pinballColl.attachedRigidbody.useGravity = true;
            //holdBall.SetActive(false);
        }
    }
}
