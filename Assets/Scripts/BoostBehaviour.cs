using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class BoostBehaviour : MonoBehaviour
    {
        [SerializeField]
        float timer;

        UnityStandardAssets.Vehicles.Car.CarController maxSpd;
        Rigidbody carSpd;
        

        // Use this for initialization
        void OnEnable()
        {

            maxSpd = GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
            carSpd = GetComponent<Rigidbody>();

            maxSpd.MaxSpeed = 200;

            //Meant to increase current speed by such
            carSpd.AddForce(carSpd.velocity*50, ForceMode.Acceleration);
            //

            timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            

            if (timer >= 1.5)
            {
                carSpd.AddForce(-carSpd.velocity);
                maxSpd.MaxSpeed = 150;
                timer = 0;
                this.enabled = false;
            }
        }
    }
}