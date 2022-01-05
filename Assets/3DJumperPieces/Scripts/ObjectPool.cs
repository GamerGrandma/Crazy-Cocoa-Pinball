using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;//pool of alligators
    public GameObject objectsToPool;
    public GameObject[] objectsToRandomize;//alligators and logs, or bonus and lives.
    public int amountToPool;
    //pooledLogs
    private int nextObject = 0;

    void Awake()
    {
       
    }
    void Start()
    {
        CreateObjectPool();
    }
    public void CreateObjectPool()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            pooledObjects.Add(ChooseRandomObject());
            pooledObjects[i].SetActive(false);
        }
    }
    public GameObject ChooseRandomObject()
    {
        GameObject randomObject;
        int objectIndex = Random.Range(0, objectsToRandomize.Length);
        randomObject = Instantiate(objectsToRandomize[objectIndex]);
        return randomObject;
        //create a random array to get pool list from
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
