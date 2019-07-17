using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class ShieldBehaviour : MonoBehaviour
    {
        [SerializeField]
        GameObject user;

        bool isShielded;

        // Update is called once per frame
        void OnEnable()
        {
            if (user == null)
            {
                //This accounts for a messup on your end
                user = GetComponent<GameObject>();
            }
        }

        private void Update()
        {
            //This gives a second for the item's hit function to fail before shutdown.
            //Hopefully.
            var shieldActivate = user.GetComponent<CarFactorBehaviour>();
            if (shieldActivate.shieldOn == false)
            {
                this.enabled = false;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Item")
            {
                //If hit by an item, the shield will eventually be shut down
                var shieldActivate = user.GetComponent<CarFactorBehaviour>();
                shieldActivate.shieldOn = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var shieldActivate = user.GetComponent<CarFactorBehaviour>();
                shieldActivate.shieldOn = false;
                //
                //Meant to lower current speed by such
                collision.rigidbody.AddForce(collision.rigidbody.velocity / 50);
            }
        }
    }
}