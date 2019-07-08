using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// when a carfactorbehaviour enters this trigger volume
/// increment it'sWayPointPass
/// </summary>
public class WayPointBehaviour : MonoBehaviour {
    //why doesn't the cart handle this?
    private void OnTriggerEnter(Collider other)
    {
        
        var cb = other.GetComponent<CarFactorBehaviour>();
        cb.WayPointPass += 1;
    }
}
