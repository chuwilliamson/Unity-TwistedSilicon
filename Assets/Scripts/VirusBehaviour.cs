using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehaviour : MonoBehaviour {

    GameObject user;
    GameObject target;
    List<GameObject> placement;

    float counter;

	// Use this for initialization
	void Start () {
        //Meant to represent starting speed
        rigidbody.constantForce *= 180;
        //
        if (user != placement[0])
        {
            target = placement[0];
        }
        else
        {
            target = placement[1];
        }

        //Meant to lower current speed by such
        target.gameObject.velocity -= 80;
        //

        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime * 180;
        if (counter >= 180)
        {
            enabled = false;
        }
	}
}
