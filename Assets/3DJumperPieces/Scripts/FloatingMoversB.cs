﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMoversB : MonoBehaviour
{
    public float minSpeed = 3f;
    public float maxSpeed = 6f;
    public float moveSpeed = 7f;
    private float leftBound = 20f;
    private float rightBound = -20f;
    public SpawnManager spawnManager;

    void Start()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        moveSpeed = spawnManager.speed;
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        if (transform.position.x > leftBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < rightBound)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag( "Player"))
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