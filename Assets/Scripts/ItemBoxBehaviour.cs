using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class ItemBoxBehaviour : MonoBehaviour
    {
        
        float respawn;

        GameObject itemCrystal;
        private void Start()
        {
            itemCrystal = GetComponent<GameObject>();
            
        }

        // Update is called once per frame
        void Update()
        {
            //Checks to see if the item box is still not active
            if (respawn <= 240)
            {
                
                itemCrystal.SetActive(false);
                respawn += Time.deltaTime * 60;
            }
            else
            {
                itemCrystal.SetActive(true);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            //Makes sure that a car is hitting the item box, while also making sure the box is there
            if (other.gameObject.tag == "Player" && respawn >= 240)
            {
                var value = other.GetComponent<CarFactorBehaviour>(); 
                //Gives an item to the car colliding with it, then disappears for a set time
                if (value.itemValue != 0)
                {
                    value.itemValue = Random.Range(1, 100);

                    respawn = 0;
                }

                // Ideas: Create random definition for Target Item
                //        Create random Power_prefab for each item, then spawn when necessary

            }
        }
    }
}