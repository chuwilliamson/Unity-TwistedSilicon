using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class TrueMissleBehaviour : MonoBehaviour
    {
        //This makes sure the user doesn't shoot themselves at high speeds
        GameObject user;

        public GameObject User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Tracking;

        GameObject Tracked;


        //This just gives the ability to push it
        Rigidbody lsr;

        // Use this for initialization
        void Start()
        {
            lsr = GetComponent<Rigidbody>();
            User.GetComponent<GameObject>().tag = "LockOff";
        }

        private void Update()
        {
            //NOW GO
            if (Tracking == false)
            {
                lsr.AddForce(lsr.transform.forward * 200);
            }
            
            
            if (Tracking == true)
            {
                Vector3 Direction = Tracked.transform.parent.parent.position - transform.position;
                transform.forward = Direction.normalized;
                transform.position += Direction * (Time.deltaTime * 200);
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "LockOn" && Tracking == false)
            {
                Tracked = other.gameObject;

                Tracking = true;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            CarFactorBehaviour shieldCheck = collision.gameObject.GetComponent<CarFactorBehaviour>();
            if ((collision.gameObject.tag == "Player" && shieldCheck.shieldOn == false) || (collision.gameObject.tag == "Player 2" && shieldCheck.shieldOn == false) || (collision.gameObject.tag == "Player 3" && shieldCheck.shieldOn == false) || (collision.gameObject.tag == "Player4" && shieldCheck.shieldOn == false))
            {
                //Meant to lower car's current speed by such
                collision.rigidbody.AddForce(-collision.rigidbody.velocity / 30);
                Destroy(gameObject);
                User.GetComponent<GameObject>().tag = "LockOn";
                Tracking = false;
            }

            //If it hits anything that isn't the user of the item
            if (collision.gameObject != user)
            {
                Destroy(gameObject);
                User.GetComponent<GameObject>().tag = "LockOn";
                Tracking = false;
            }

            if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
                User.GetComponent<GameObject>().tag = "LockOn";
                Tracking = false;

            }
        }
    }
}
