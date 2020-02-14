using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ARSessionOrigin>())
        {
            // trigger something in the environment
            Debug.Log("entered area");
        }
    }
}
