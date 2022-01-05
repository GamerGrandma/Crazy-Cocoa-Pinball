using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floater"))
        {
            Debug.Log("object in boundary");
            other.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bonus"))
        {
            Debug.Log("object in boundary");
            other.gameObject.SetActive(false);
        }
    }
    
}
