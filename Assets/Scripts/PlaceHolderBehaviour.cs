using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beaux
{
    public class PlaceHolderBehaviour : MonoBehaviour
    {

        GameObject play1;
        GameObject play2;
        GameObject play3;
        GameObject play4;

        List<GameObject> placement;

        // Use this for initialization
        void Start()
        {
            if (play1 != null)
            {
                placement.Add(play1);
            }
            if (play2 != null)
            {
                placement.Add(play2);
            }
            if (play3 != null)
            {
                placement.Add(play3);
            }
            if (play4 != null)
            {
                placement.Add(play4);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < placement.Count; i++)
            {
                for (int j = 0; j < placement.Count; j++)
                {
                    //Can't remember how to call script's piece without getComponent
                    //if ((placement[j].CarFactorBehaviour.wayPointPass>placement[i].CarFactorBehaviour.wayPointPass) && j>i)//
                    //{
                    //    List<GameObject> temp = placement;
                    //    temp[i] = placement[j];
                    //    temp[j] = placement[i];
                    //    placement = temp;
                    //}
                }
            }
        }
    }
}