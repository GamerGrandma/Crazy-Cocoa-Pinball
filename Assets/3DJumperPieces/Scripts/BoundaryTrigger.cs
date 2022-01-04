using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floater"))
        {
            Debug.Log("floater in boundary");
            other.gameObject.SetActive(false);
        }
    }
    
}
