using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBehaviour : MonoBehaviour {

    float timer;

	// Use this for initialization
	void Start () {
        //Can't remember how to call script's piece without getComponent
        CarController.Topspeed = 200;
        //

        //Meant to increase current speed by such
        rigidbody.velocity += 50;
        //

        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * 60;

        if (timer >= 240)
        {
            //Can't remember how to call script's piece without getComponent
            CarController.Topspeed = 150;
            //
            enabled = false;
        }
	}
}
