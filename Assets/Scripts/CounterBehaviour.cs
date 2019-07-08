using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CounterBehaviour : MonoBehaviour {
    public GameObject[] finishLine;
    public int lapCounter = 0;
//    private NavMeshAgent agent;


    void Start ()
    {
       // agent = GetComponent<NavMeshAgent>();
        goUp();
    }

    void goUp()
    {
        if (finishLine.Length == 5)
        {
            lapCounter++;
        }

        //agent.destination = finishLine[0].transform.position;

    }

    void Update ()
    {
     //   if (!agent.pathPending && agent.remainingDistance < 50)
      //  {
            goUp();
     //   }

    }
}
