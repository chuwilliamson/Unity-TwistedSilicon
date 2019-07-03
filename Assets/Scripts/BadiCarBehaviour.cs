using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadiCarBehaviour : MonoBehaviour {

    public GameObject[] Waypoint;
    private int curntpoint = 0;
    private NavMeshAgent agent;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        //doing this keeps it seek instead of arrive^


        NextPoint();
	}

    void NextPoint()
    {

        if (Waypoint.Length == 0)
        {
            return;
        }
        //incase No points are set up^

        agent.destination = Waypoint[curntpoint].transform.position;

        curntpoint = (curntpoint + 1) % Waypoint.Length;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 50)
        {
            NextPoint();
        }
    }
}
