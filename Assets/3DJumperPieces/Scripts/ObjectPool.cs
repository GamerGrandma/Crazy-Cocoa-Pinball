using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;//pooledAlligators
    public GameObject objectToPool;//alligators
    public int amountToPool;
    //pooledLogs
    //logs
    //same for bonus objects
    private float leftBound = 22f;
    private float rightBound = -22f;

    void Awake()
    {
        //SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        //GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            pooledObjects.Add(Instantiate(objectToPool));
            pooledObjects[i].SetActive(false);
        }
    }
    void Update()
    {
        
    }
    public GameObject SpawnObject(Vector3 position)
    {
        int nextObject = 0;
        GameObject toReturn;
        if (nextObject <= pooledObjects.Count)
        {
            toReturn = pooledObjects[nextObject];
            toReturn.SetActive(true);
            toReturn.transform.position = position;
            
            nextObject++;
            return toReturn;
        }
        else if (nextObject > pooledObjects.Count)
        {
            nextObject = 0;
            
        }
        return null;
    }
    //method for shoosing random floater to activate
    //method for choosing random bonus object
   /* public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }*/
    
}
