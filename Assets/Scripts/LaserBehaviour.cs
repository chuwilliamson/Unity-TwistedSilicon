using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class LaserBehaviour : MonoBehaviour
    {
        

        Rigidbody lsr;
        //Vector3 origin;

        // Use this for initialization
        void Start()
        {
            lsr = GetComponent<Rigidbody>();
            //origin = -lsr.transform.forward;
            //lsr.AddForce(lsr.transform.forward * 20000);
        }

        private void Update()
        {
            //Vector3 displacement = lsr.transform.position - origin;
            //displacement.Normalize();
            //lsr.transform.position += displacement * 200;
            lsr.AddForce(lsr.transform.forward * 200);
            //lsr.transform.position += lsr.transform.forward * 200000;

        }

        private void OnCollisionEnter(Collision collision)
        {
            CarFactorBehaviour shieldCheck = collision.gameObject.GetComponent<CarFactorBehaviour>();
            if (collision.gameObject.tag == "Player" && shieldCheck.shieldOn == false)
            {
                //Meant to lower car's current speed by such
                collision.rigidbody.AddForce(-collision.rigidbody.velocity/30);
            }
            Destroy(GetComponent<GameObject>());
        }
    }
}