using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject crystal;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //carValues will be a classsss/behaviour (not sure which) that will hold the item of the user
            //itemValue will be that int val
            //if (other.gameObject.carValues.itemValue != 0)
            //{
            //    other.gameObject.carValues.itemValue = Random.Range(1, 100);
            //    if (other.gameObject.carValues.itemValue <=1 && 
            //        other.gameObject.carValues.itemValue >= 20)
            //    {
            //        crystal.ActivateTrigger.Target = 
            //    }
            //    if (other.gameObject.carValues.itemValue <= 21 && 
            //        other.gameObject.carValues.itemValue >= 40)
            //    {

            //    }
            //    if (other.gameObject.carValues.itemValue <= 41 && 
            //        other.gameObject.carValues.itemValue >= 60)
            //    {

            //    }
            //    if (other.gameObject.carValues.itemValue <= 61 && 
            //        other.gameObject.carValues.itemValue >= 80)
            //    {

            //    }
            //    if (other.gameObject.carValues.itemValue <= 81 && 
            //        other.gameObject.carValues.itemValue >= 100)
            //    {

            //    }
            //}

            // Icon = GetComponent(thething)
            // Icon.Enable;

            // Ideas: Create random definition for Target Item
            //        Create random Power_prefab for each item, then spawn when necessary

        }
    }

}
