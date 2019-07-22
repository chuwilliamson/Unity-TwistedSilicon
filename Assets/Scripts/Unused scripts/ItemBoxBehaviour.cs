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
        [SerializeField]
        GameObject itemCrystal;

        [SerializeField]
        GameObject crystalPrefab;

        Vector3 crystalPos;
        Quaternion crystalRot;

        //float timer;
        private void Start()
        {
            //timer = 240;
            crystalPos = new Vector3(itemCrystal.transform.position.x,
                        itemCrystal.transform.position.y, itemCrystal.transform.position.z);
            crystalRot = new Quaternion(itemCrystal.transform.rotation.x,
                itemCrystal.transform.rotation.y, itemCrystal.transform.rotation.z,
                    itemCrystal.transform.rotation.z);
        }

        // Update is called once per frame
        void Update()
        {
            //if (timer <= 240 && itemCrystal == null)
            //{
            //    itemCrystal = Instantiate(crystalPrefab, crystalPos,
            //                                crystalRot);
            //}
            //else if (timer > 240)
            //{
            //    timer += Time.deltaTime * 60;
            //}
        }

        void OnTriggerEnter(Collider other)
        {
            //Makes sure that a car is hitting the item box, while also making sure the box is there
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<CarFactorBehaviour>() == null)
                {
                    var parent = other.gameObject.GetComponent<GetParentBehaviour>();
                    other = parent.Parent.GetComponent<Collider>();
                }

                var value = other.GetComponent<CarFactorBehaviour>(); 
                //Gives an item to the car colliding with it, then disappears for a set time
                if (value.itemValue != 0)
                {
                    //Sets the item code for the car
                    value.itemValue = Random.Range(1, 100);
                }

                Destroy(itemCrystal);
                //timer = 0;
                StartCoroutine(WaitForTime());
                itemCrystal = Instantiate(crystalPrefab, crystalPos,
                                            crystalRot);
            }
        }

        IEnumerator WaitForTime()
        {
            yield return new WaitForSecondsRealtime(5);
        }
    }
}