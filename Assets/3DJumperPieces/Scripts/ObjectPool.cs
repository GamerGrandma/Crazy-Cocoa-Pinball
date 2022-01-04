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
    public GameObject bonusToPool;
    private int nextObject = 0;

    void Awake()
    {
       
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
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
        
        GameObject toReturn;
        if (nextObject <= pooledObjects.Count)
        {
            toReturn = pooledObjects[nextObject];
            toReturn.SetActive(true);
            toReturn.transform.position = position;
            nextObject++;
            if (nextObject >= pooledObjects.Count)
            {
                nextObject = 0;
            }
            return toReturn;
        }
        return null;
    }
    //method for shoosing random floater to activate
    //method for choosing random bonus object
   
    
}
