using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovers : MonoBehaviour
{
    public float minSpeed = 3f;
    public float maxSpeed = 6f;
    public float moveSpeed = 7f;
    private float leftBound = 22f;
    private float rightBound = -22f;
    public SpawnManager spawnManager;
    public ObjectPool objectPooler;
    public GameObject floater;

    void Start()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        objectPooler = GameObject.Find("Spawner").GetComponent<ObjectPool>();
        moveSpeed = spawnManager.speed;
        //floater = ObjectPool.SharedInstance.GetPooledObject();
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if(transform.position.x > leftBound)
        {
          // floater.SetActive(false);
        }
        /*else if (transform.position.x < rightBound)
        {
            this.SetActive(false);
        }*/
        
    }
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
