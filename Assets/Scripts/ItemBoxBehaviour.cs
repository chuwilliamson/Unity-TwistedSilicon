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
            
            if (respawn <= 240)
            {

                itemCrystal.SetActive(false);
                respawn += Time.deltaTime * 60;
            }
            else
            {
                itemCrystal.SetActive(false);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && respawn >= 240)
            {
                var value = other.GetComponent<CarFactorBehaviour>(); 
                //carValues will be a classsss/behaviour (not sure which) that will hold the item of 
                //the user
                //itemValue will be that int val
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