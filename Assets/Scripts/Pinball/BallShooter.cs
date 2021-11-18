using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public bool shooterIsReleased;
    //&& shooter is released to if collision statement
    public float speed = 5.0f;
    //speed changer that depends on position of shooter
    void Start()
    {
        
    }
    
    void Update()
    {
        //move shooter control here in update
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShooterPullBack();
        }
        //if space up release plunger method happens
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShooterRelease();
        }
    }
    void ShooterPullBack()
    {
        this.transform.Translate(0, 0, -2.5f, Space.World);
        shooterIsReleased = false;
        // activate a spring to move the shooter instead of transform
    }
    void ShooterRelease()
    {
        this.transform.Translate(0, 0, 2.5f, Space.World);
        shooterIsReleased = true;
        // deactivate a spring
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pinball") && shooterIsReleased == true)
        {
            Rigidbody pinballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromObstacle = collision.gameObject.transform.position - transform.position;
            pinballRb.AddForce(awayFromObstacle * speed, ForceMode.Impulse);

        }
    }
}
