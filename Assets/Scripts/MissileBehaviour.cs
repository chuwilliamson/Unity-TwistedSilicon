using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour {

    GameObject user;
    GameObject target;
    List<GameObject> placement;

	// Use this for initialization
	void Start () {
        //Meant to represent starting speed
        rigidbody.constantForce *= 180;
        //

        if (user == placement[0])
        {
            target = placement[1];
        }
        else if (user == placement[1])
        {
            target = placement[0];
        }
        else if (user == placement[2])
        {
            target = placement[1];
        }
        else if (user == placement[3])
        {
            target = placement[2];
        }
    }
	
	// Update is called once per frame
	void Update () {
		//target changed to car
	}
    private void OnCollisionEnter(Collision collision)
    {
        //Can't remember how to call script's piece without getComponent
        if(collision.gameObject.tag == "Player" && collision.gameObject.CarFactorBehaviour.
                                                    shieldOn == false)//
        {
            //Meant to lower current speed by such
            collision.rigidbody.velocity -= 40;
            //
        }
    }
}
