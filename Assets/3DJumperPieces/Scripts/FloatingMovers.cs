using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovers : MonoBehaviour
{
    public float moveSpeed;
    public SpawnManager spawnManager;
    public GameObject floater;

    void Start()
    {
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        moveSpeed = spawnManager.Speed;
    }
    
    void Update()
    {
        Move();
    }
    //ABSTRACTION method for moving floaters.
    //POLYMORPHISM method can be overridden in inherited classes.
    public virtual void Move()
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
