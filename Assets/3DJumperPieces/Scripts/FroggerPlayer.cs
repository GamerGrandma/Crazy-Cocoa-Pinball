using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerPlayer : MonoBehaviour
{
    public SpawnManager spawnManager;
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    Vector3 velocity;
    public float speed = 1f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool landedInWater = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
    }
    
    void Update()
    {
        MoveAround();
        PlayerLost();
    }
    //ABSTRACTION method moving the player
    void MoveAround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    //ABSTRACTION method for losing player life
    void PlayerLost()
    {
        if (landedInWater == true)
        {
            Destroy(gameObject);
            Debug.Log("you lost your life");
            spawnManager.LosePlayerLife(1);
        }
        else if (transform.position.x <= -23)
        {
            Destroy(gameObject);
            Debug.Log("you lost your life");
            spawnManager.LosePlayerLife(1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            landedInWater = true;
        }
    }
}
