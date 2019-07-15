using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Beaux
{
    public class CarFactorBehaviour : MonoBehaviour
    {
        [SerializeField]
        GameObject car;

        [SerializeField]
        GameObject scrnUI;

        [SerializeField]
        GameObject buttons;

        [SerializeField]
        GameObject LaserPrefab;

        [SerializeField]
        GameObject RocketPrefab;

        public int itemValue;

        public bool shieldOn;

        int wayPointPass;

        public int WayPointPass
        {
            get { return wayPointPass; }
            set { wayPointPass = value; }
        }
        List<ButtonRange> buttonRanges;
        // Use this for initialization
        void Start()
        {
            shieldOn = false;
            wayPointPass = 0;

            //Creates each button and its value range
            var children = buttons.GetComponentsInChildren<GameObject>();
            int min = 1;
            int max = min + 19;
            foreach (var child in children)
            {
                var br = new ButtonRange
                {
                    button = child,
                    range = new Vector2(min, max)
                };
                min = max;
                max += 20;
                buttonRanges.Add(br);
            }
            
        }

        //Holds button, the range of values that equals it, and the script's activation.
        public class ButtonRange
        {
            public GameObject button;
            public Vector2 range;
            public UnityEngine.Events.UnityEvent Response;
        }
        public ButtonRange GetTheButton(int itemvaluecheck)
        {
            //Goes through the list and finds the correct value for the item
            foreach (var br in buttonRanges)
            {
                var isTheButton = (itemvaluecheck >= br.range.x && itemvaluecheck <= br.range.y);
                if (isTheButton)
                    return br;
            }

            return null;

        }

        GameObject turnThisOff;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                var thebutton = GetTheButton(itemValue);
                if (thebutton != null)
                {
                    thebutton.button.SetActive(true);
                }
                //////////THIS IS LIST OF ITEM USAGE CODE//////////////////////////////////
                if (itemValue >= 41 && itemValue <= 60)
                {
                    car.GetComponent<ShieldBehaviour>().enabled = true;
                    shieldOn = true;
                }

                if (itemValue >= 61 && itemValue <=80)
                {
                    var boostBehaviour = car.GetComponent<BoostBehaviour>().enabled = true;
                }

                //Still unsure the true purpose of this. I think I have to set a function for the 
                // corresponding button
                thebutton.Response.Invoke();
            }

            //TEST CODE DO NOT USE
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                GameObject newLaser = Instantiate(LaserPrefab, new Vector3(car.transform.position.x, 
                                        car.transform.position.y+1, 
                                        car.transform.position.z),
                                            car.transform.rotation);

                newLaser.transform.forward = car.transform.forward;
                newLaser.transform.position += newLaser.transform.forward * 5;
            }


            //0      no item
            //1-20   missile
            //21-40  laser
            //41-60  shield
            //61-80  boost
            //81-100 virus

            ///////////////////////////////////////////////////////////////////////////////////////

            //if (itemValue <= 1 && itemValue >= 20)
            //{
            //need to figure out where to activate the button for the UI
            //    buttons.SetActive(true);

            //
            //    if (Input.GetKeyDown(KeyCode.Return))
            //    {
            //create missile
            //take off of UI
            //    }
            //}
            //if (itemValue <= 21 && itemValue >= 40)
            //{
            //need to figure out where to activate the button for the UI
            //    buttons.SetActive(true);
            //
            //    if (Input.GetKeyDown(KeyCode.Return))
            //    {
            //Create laser
            //take off of UI
            //    }
            //}
            //if (itemValue <= 41 && itemValue >= 60)
            //{
            //need to figure out where to activate the button for the UI
            //    buttons.Shield.Active();
            //
            //    shieldOn = true;
            //    if (Input.GetKeyDown(KeyCode.Return))
            //    {
            //shield behaviour(make it connected to car)
            //take off of UI
            //    }
            //}
            //if (itemValue <= 61 && itemValue >= 80)
            //{
            //need to figure out where to activate the button for the UI
            //  buttons.Boost.Active();
            //
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            //Run boost script
            //take off of UI
            //}
            //}
            //if (itemValue <= 81 && itemValue >= 100)
            //{
            //need to figure out where to activate the button for the UI
            //  buttons.VirusBehaviour.Enable();
            //
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            //Run virus script
            //take off of UI
            //}
            //}
        }
    }
}