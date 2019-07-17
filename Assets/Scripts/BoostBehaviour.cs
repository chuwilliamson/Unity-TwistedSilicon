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
            //This script is called specifically, for the maxSpeed allowed for the car
            maxSpd = GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
            //This is called specifically to give the car the force for the boost
            carSpd = GetComponent<Rigidbody>();

            //Increases for the boost, and meant to increase current speed by such
            maxSpd.MaxSpeed = 200;
            carSpd.AddForce(carSpd.velocity*50, ForceMode.Acceleration);

            timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //Adds to the timer til shutdown
            timer += Time.deltaTime;
            
            // Checks if the boost has ended or not
            if (timer >= 1.5)
            {
                //Takes speed off, lowers max spd, timer set back to 0, boost script turned off
                carSpd.AddForce(-carSpd.velocity);
                maxSpd.MaxSpeed = 150;
                timer = 0;
                this.enabled = false;
            }
        }
    }
}