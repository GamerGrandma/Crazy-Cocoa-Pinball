using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        /* if (other.gameObject.CompareTag("Floater"))
         {
             Debug.Log("floater in boundary");
             other.gameObject.SetActive(false);
             if (other.gameObject.CompareTag("Bonus"))
             {
                 Debug.Log("bonus in boundary");
                 other.gameObject.SetActive(false);
             }
         }*/
    }
    void OnTriggerExit(Collider other)
    {
        
    }
    
}
