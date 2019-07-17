using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class ItemBoxBehaviour : MonoBehaviour
    {
        // The timer until the crystal reappears
        float respawn;

        //This will simply hold the gameobjexct so I don't have the call it again and clarity.
        public GameObject itemCrystal;
        private void Start()
        {
          //  itemCrystal = GetComponent<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            //Checks to see if the item box is still not active
            if (respawn <= 240)
            {
                //Increases if otherwise, but keeps off
               // itemCrystal.SetActive(false);
                respawn += Time.deltaTime * 60;
            }
            else
            {
                //turns on
                itemCrystal.SetActive(true);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            //Makes sure that a car is hitting the item box, while also making sure the box is there
            if (other.gameObject.tag == "Player"/* && respawn >= 240*/)
            {
                itemCrystal.SetActive(false);
                //var value = other.GetComponent<CarFactorBehaviour>(); 
                ////Gives an item to the car colliding with it, then disappears for a set time
                //if (value.itemValue != 0)
                //{
                //    //Sets the item code for the car
                //    value.itemValue = Random.Range(1, 100);
                //    //Then sets the box back to false
                //    respawn = 0;
                //}

            }
        }
    }
}