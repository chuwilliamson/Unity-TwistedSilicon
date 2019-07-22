using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {

    public GameObject[] Laps;
    public int[] NumberHoldings;
    public float spedyness;
    public GameObject sped;
    public GameObject[] txt;
    public GameObject spedyboi;

    void Update ()
    {
        NumberHoldings[0] = Laps[0].GetComponent<CounterBehaviour>().lapCounter;
        NumberHoldings[1] = Laps[1].GetComponent<CounterBehaviour>().lapCounter;
        NumberHoldings[2] = Laps[2].GetComponent<CounterBehaviour>().lapCounter;
        NumberHoldings[3] = Laps[3].GetComponent<CounterBehaviour>().lapCounter;
        NumberHoldings[4] = Laps[4].GetComponent<DeathWallBehaviour>().LapCounter;

        txt[0].GetComponent<Text>().text = "Player 1 Laps: " + NumberHoldings[0];
        txt[1].GetComponent<Text>().text = "Player 2 Laps: " + NumberHoldings[1];
        txt[2].GetComponent<Text>().text = "Player 3 Laps: " + NumberHoldings[2];
        txt[3].GetComponent<Text>().text = "Player 4 Laps: " + NumberHoldings[3];
        txt[4].GetComponent<Text>().text = "DeathWall Laps: " + NumberHoldings[4];

        spedyness = spedyboi.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().CurrentSpeed;

        sped.GetComponent<Text>().text = "KPH: " + spedyness;
    }
}
