using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject lostBallTrigger;
    public GameObject pinballPrefab;
    //public GameObject paddleUL;
    //public GameObject paddleBL;
    //public GameObject paddleUR;
    //public GameObject paddleBR;
    public float speed = 5.0f;
    public bool pinballInPlay;
    public bool gameIsOver = false;
    public int numOfPinball;
    private float ballLost = -5f;

    void Start()
    {
        //do i have to get rigidbodies of pinball, shooters and paddles here?
        //instantiate 1st pinball here
        Instantiate(pinballPrefab, new Vector3(10.75f, 0.5f, -14f),Quaternion.identity);
        pinballInPlay = true;
        numOfPinball = 3;
    }
    //trigger spot for destroy pinball and reset if less than 3 balls
    //need key inputs and action control to use shooter and paddles
    void Update()
    {
        //check for spacebar input here
        if (transform.position.z > ballLost && gameObject.CompareTag("Pinball"))
        {
            Destroy(gameObject);
        }
        
    }
    
    void RotateLeftPaddles()
    {
        
    }
    void RotateRightPaddles()
    {
        //find objects with tag right paddle
    }
    void StartNextPinball()
    {
            //if numOfPinball > 0 instantiate new pinballPrefab;
            //numOfPinball -=;
            //pinballInPlay = true;
    }
    void OnTriggerEnter()
    {
        
        //this is what happens when pinball enters ballLostTrigger
        //Destroy pinballPrefab;
        //pinballInPlay = false;
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shooter"))
        {
            Rigidbody pinballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromObstacle = collision.gameObject.transform.position - transform.position;
            pinballRb.AddForce(awayFromObstacle * speed, ForceMode.Impulse);

        }
    }*/
}
