using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObjects : MonoBehaviour
{
    public float minSpeed = 3f;
    public float maxSpeed = 6f;
    public float moveSpeed = 7f;
    public SpawnManager spawnManager;
    public int pointsToAdd;
    public bool addPoints = false;

    void Start()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        moveSpeed = spawnManager.Speed;       
    }
    
    void Update()
    {
        Move();
        AddingPoints();
    }
    public void Move()
    {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //add points or life here.
            //and Destroy(gameObject);
            addPoints = true;
        }
    }
    void AddingPoints()
    {
        if (addPoints == true)
        {
            Destroy(gameObject);
            Debug.Log("you got points");
            spawnManager.AddSomePoints(pointsToAdd);
        }
    }
}
