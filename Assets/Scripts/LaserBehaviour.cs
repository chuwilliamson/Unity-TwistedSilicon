using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class LaserBehaviour : MonoBehaviour
    {

        GameObject user;

        Rigidbody lsrSpd;

        // Use this for initialization
        void Start()
        {
            lsrSpd = GetComponent<Rigidbody>();
            transform.forward = user.transform.forward;
            lsrSpd.AddForce(transform.forward * 200);
        }

        private void OnCollisionEnter(Collision collision)
        {
            CarFactorBehaviour shieldCheck = collision.gameObject.GetComponent<CarFactorBehaviour>();
            if (collision.gameObject.tag == "Player" && shieldCheck.shieldOn == false)
            {
                //Meant to lower current speed by such
                collision.rigidbody.AddForce(collision.rigidbody.velocity/30);
            
            }
        }
    }
}