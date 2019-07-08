using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

    GameObject user;

	// Use this for initialization
	void Start () {
        transform.forward = user.transform.forward;
        //Meant to represent starting speed
        rigidbody.constantForce *= 200;
        //
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.CarFactorBehaviour.
                                                    shieldOn == false)
        {
            //Meant to lower current speed by such
            collision.rigidbody.velocity -= 30;
            //
        }
    }
}
