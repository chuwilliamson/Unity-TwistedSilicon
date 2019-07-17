using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// when a carfactorbehaviour enters this trigger volume
/// increment it'sWayPointPass
/// </summary>
/// 

namespace Beaux
{
    public class WayPointBehaviour : MonoBehaviour
    {
        //why doesn't the cart handle this? - Mr. Matt
        // Because this is a trigger function
        private void OnTriggerEnter(Collider other)
        {
            //The car increases its waypoint number to adjust their positions/missile targets
            var cb = other.GetComponent<CarFactorBehaviour>();
            cb.WayPointPass += 1;
        }
    }
}
