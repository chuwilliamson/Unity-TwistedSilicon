using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class MissileBehaviour : MonoBehaviour
    {

        GameObject user;
        public GameObject User
        {
            get { return user; }
            set { user = value; }
        }

        GameObject target;
        List<GameObject> placement;

        // Use this for initialization
        void Start()
        {
            //Meant to represent starting speed
            //rigidbody.constantForce *= 180;
            //

            if (user == placement[0])
            {
                target = placement[1];
            }
            else if (user == placement[1])
            {
                target = placement[0];
            }
            else if (user == placement[2])
            {
                target = placement[1];
            }
            else if (user == placement[3])
            {
                target = placement[2];
            }
        }

        // Update is called once per frame
        void Update()
        {
            //target changed to car
        }
        private void OnCollisionEnter(Collision collision)
        {
            CarFactorBehaviour shieldCheck = collision.gameObject.GetComponent<CarFactorBehaviour>();
            if (collision.gameObject.tag == "Player" && shieldCheck.shieldOn == false)
            {
                //Meant to lower car's current speed by such
                collision.rigidbody.AddForce(-collision.rigidbody.velocity / 40);
            }

            //If it hits anything that isn't the user of the item
            if (collision.gameObject != user)
            {
                Destroy(gameObject);
            }
        }
    }
}