using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour {
    [SerializeField]
    public GameObject car;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(car.transform.position.x-5, car.transform.position.y + 3, 
                            car.transform.position.z);


	}
}
