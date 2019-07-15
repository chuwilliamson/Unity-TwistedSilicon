using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class ShieldBehaviour : MonoBehaviour
    {
        [SerializeField]
        GameObject user;

        // Update is called once per frame
        void OnEnable()
        {
            if (user == null)
            {
                user = GetComponent<GameObject>();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Item")
            {
                var shieldActivate = user.GetComponent<CarFactorBehaviour>();
                shieldActivate.shieldOn = false;
                //
                this.enabled = false;
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
                //
                this.enabled = false;
            }
        }
    }
}