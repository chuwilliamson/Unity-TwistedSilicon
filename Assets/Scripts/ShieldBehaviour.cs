using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {

    GameObject user;
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "item")
        {
            //Can't remember how to call script's piece without getComponent
            user.CarFactorBehaviour.shieldOn = false;
            //
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Can't remember how to call script's piece without getComponent
            user.CarFactorBehaviour.shieldOn = false;
            //
            //Meant to lower current speed by such
            collision.rigidbody.velocity -= 50;
            //
        }
    }
}
