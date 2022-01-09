using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovers : MonoBehaviour
{
    public float minSpeed = 3f;
    public float maxSpeed = 6f;
    public float moveSpeed = 7f;
    public SpawnManager spawnManager;
    public GameObject floater;

    void Start()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        moveSpeed = spawnManager.speed;
    }
    
    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }
    //can ontriggerenter be private virtual?
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //land on floater and add speed
            other.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
