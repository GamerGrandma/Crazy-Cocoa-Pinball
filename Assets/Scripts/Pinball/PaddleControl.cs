using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public float speed = 30f;
    // need bool for paddle is moving
    //&& paddle is moving to if collision statement
    void Start()
    {
        
    }
    
    void Update()
    {
        // move paddle control here
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftPaddle.transform.Rotate(0, -30f, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            leftPaddle.transform.Rotate(0, 30f, 0);
        }
        //if 'l' down rotate right paddles on y axis -20(rotaterightpaddle method)
        if (Input.GetKeyDown(KeyCode.L))
        {
            rightPaddle.transform.Rotate(0, 30f, 0);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            rightPaddle.transform.Rotate(0, -30f, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            Rigidbody pinballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromObstacle = collision.gameObject.transform.position - transform.position;
            pinballRb.AddForce(awayFromObstacle * speed, ForceMode.Impulse);

        }
    }
}
