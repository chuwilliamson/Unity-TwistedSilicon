using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class LaserBehaviour : MonoBehaviour
    {
        //This makes sure the user doesn't shoot themselves at high speeds
        GameObject user;

        public GameObject User
        {
            get { return user; }
            set { user = value; }
        }

        //This just gives the ability to push it
        Rigidbody lsr;

        // Use this for initialization
        void Start()
        {
            lsr = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //NOW GO
            lsr.AddForce(lsr.transform.forward * 200);
        }

        private void OnCollisionEnter(Collision collision)
        {
            CarFactorBehaviour shieldCheck = collision.gameObject.GetComponent<CarFactorBehaviour>();
            if (collision.gameObject.tag == "Player" && shieldCheck.shieldOn == false)
            {
                //Meant to lower car's current speed by such
                collision.rigidbody.AddForce(-collision.rigidbody.velocity/30);
            }
            
            //If it hits anything that isn't the user of the item
            if (collision.gameObject != user)
            {
                Destroy(gameObject);
            }
        }
    }
}