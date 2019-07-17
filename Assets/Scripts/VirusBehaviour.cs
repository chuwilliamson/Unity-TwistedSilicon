using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class VirusBehaviour : MonoBehaviour
    {

        GameObject user;
        GameObject target;
        List<GameObject> placement;

        float counter;

        // Use this for initialization
        void Start()
        {

            //Targets first like a Blue Shell, or targets 2nd if you're in first.
            if (user != placement[0])
            {
                target = placement[0];
            }
            else
            {
                target = placement[1];
            }

            //Meant to lower current speed by such
            //target.gameObject.velocity -= 80;
            //Also needs the UI tomfuckery

            counter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            counter += Time.deltaTime * 180;
            if (counter >= 180)
            {
                enabled = false;
            }
        }
    }
}