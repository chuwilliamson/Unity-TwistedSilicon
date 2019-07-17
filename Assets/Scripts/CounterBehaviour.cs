using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CounterBehaviour : MonoBehaviour {
    public int lapCounter = 0;
    public bool chetCheck = true;

    void Start ()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (chetCheck == false)
        {
            if (other.gameObject.CompareTag("Waypoint"))
            {
                lapCounter++;

                chetCheck = true;
            }

        }

        if (other.gameObject.CompareTag("chetPoint"))
        {
            chetCheck = false;
        }


    }



    void Update ()
    {

    }
}
