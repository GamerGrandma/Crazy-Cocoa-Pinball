using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
