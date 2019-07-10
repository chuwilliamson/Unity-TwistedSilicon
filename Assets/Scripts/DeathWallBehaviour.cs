using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathWallBehaviour : MonoBehaviour
{

    public GameObject[] Waypoint;
    private int curntpoint = 0;
    private NavMeshAgent agent;
    public int LapCounter = 0;
    public bool chetCheck = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;


        NextPoint();
    }

    void NextPoint()
    {

        if (Waypoint.Length == 0)
        {
            return;
        }

        agent.destination = Waypoint[curntpoint].transform.position;

        curntpoint = (curntpoint + 1) % Waypoint.Length;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 50)
        {
            NextPoint();
        }

        if (curntpoint == 1 && chetCheck == false)
        {
            LapCounter++;
            chetCheck = true;
        }

        if (curntpoint == 11)
        {
            chetCheck = false;
        }

    }
}
