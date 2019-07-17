using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DeathWallBehaviour : MonoBehaviour
{

    public GameObject[] Waypoint;
    public GameObject PauseMenu;
    private int curntpoint = 0;
    private NavMeshAgent agent;
    public int LapCounter = 0;
    public bool chetCheck = true;
    public GameObject[] Players;
    public bool[] isDead;
    public bool Lost = false;
    public bool Won = false;
    public bool paused = false;


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

    void OnTriggerEnter(Collider other)
    {
        if (Players[0].GetComponent<CounterBehaviour>().lapCounter <= LapCounter)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isDead[0] = true;
                Players[0].SetActive(false);
            }
        }

        if (Players[1].GetComponent<CounterBehaviour>().lapCounter <= LapCounter)
        {
            if (other.gameObject.CompareTag("Player 2"))
            {
                isDead[1] = true;
                Players[1].SetActive(false);

            }
        }

        if (Players[2].GetComponent<CounterBehaviour>().lapCounter <= LapCounter)
        {
            if (other.gameObject.CompareTag("Player 3"))
            {
                isDead[2] = true;
                Players[2].SetActive(false);

            }
        }

        if (Players[3].GetComponent<CounterBehaviour>().lapCounter <= LapCounter)
        {
            if (other.gameObject.CompareTag("Player 4"))
            {
                isDead[3] = true;
                Players[3].SetActive(false);


            }
        }
    }

    void Update()
    {

        if (Players[0].transform.position.y <= -120)
        {
            isDead[0] = true;
            Players[0].SetActive(false);
        }

        if (Players[1].transform.position.y <= -120)
        {
            isDead[1] = true;
            Players[1].SetActive(false);
        }

        if (Players[2].transform.position.y <= -120)
        {
            isDead[2] = true;
            Players[2].SetActive(false);
        }

        if (Players[3].transform.position.y <= -120)
        {
            isDead[3] = true;
            Players[3].SetActive(false);
        }



        if (!agent.pathPending && agent.remainingDistance < 50)
        {
            NextPoint();
        }

        if (curntpoint == 2 && chetCheck == false)
        {
            LapCounter++;

            agent.speed+=20;
            agent.angularSpeed += 90;
            agent.acceleration *= 2;

            chetCheck = true;
        }

        if (curntpoint == 11)
        {
            chetCheck = false;
        }

        if (isDead[0] == true && Won == false)
        {
            Lost = true;

            SceneManager.LoadScene(2);
        }

        if (isDead[1] == true && isDead[2] == true && isDead[3] == true && Lost == false)
        {
            Won = true;

            SceneManager.LoadScene(3);
        }
        

        if (paused == false)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }

        if (paused == true)
        {
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
        }

        if(Input.GetAxis("Pause") == 1 || Input.GetKeyDown("escape"))
        {
            paused = true;
        }

    }
}
