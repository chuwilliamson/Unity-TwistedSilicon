using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject missileCrystal;
    [SerializeField]
    GameObject laserCrystal;
    [SerializeField]
    GameObject boostCrystal;
    [SerializeField]
    GameObject virusCrystal;
    [SerializeField]
    GameObject shieldCrystal;
    [SerializeField]
    Transform boxLoc;
    float respawn;

    // Update is called once per frame
    void Update()
    {
        if (respawn != 240)
        {
            //Not sure how to enable/disable the visual crystal for the itembox
            MeshRenderer.disable;
            //
            respawn += Time.deltaTime * 60;
        }
        else
        {
            //Not sure how to enable/disable the visual crystal for the itembox
            MeshRenderer.enable;
            //
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && respawn >= 240)
        {
            //carValues will be a classsss/behaviour (not sure which) that will hold the item of the user
            //itemValue will be that int val
            if (other.gameObject.carValues.itemValue != 0)
            {
                other.gameObject.CarFactorBehaviour.itemValue = Random.Range(1, 100);

                respawn = 0;
            }

            // Ideas: Create random definition for Target Item
            //        Create random Power_prefab for each item, then spawn when necessary

        }
    }
}
