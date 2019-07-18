using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Beaux
{
    public class CarFactorBehaviour : MonoBehaviour
    {
        //This is the current vehicle
        [SerializeField]
        GameObject car;

        //Last minute addition, changes a few small functions dealing with UI
        [SerializeField]
        bool isAI;


        public GameObject[] Enemies;


        bool IsAI
        {
            get { return isAI; }
        }

        //This is the UI of the game (hopefully)
        [SerializeField]
        GameObject scrnUI;

        //This should take care of the UI's buttons
        [SerializeField]
        GameObject buttons;

        //This helps create a new Laser for assignment
        [SerializeField]
        GameObject LaserPrefab;

        //This helps create a new Rocket for assignment
        [SerializeField]
        GameObject RocketPrefab;

        //This holds the code that corresponds to the item held
        public int itemValue;

        //This checks if a shield is active currently
        public bool shieldOn;

        //The waypoint counter that will affect the targetting system and the number for the UI
        int wayPointPass;

        public int WayPointPass
        {
            get { return wayPointPass; }
            set { wayPointPass = value; }
        }
        //This holds the connecting buttons with its range of equivalent values
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
            //foreach (var child in children)
            //{
            //    var br = new ButtonRange
            //    {
            //        button = child,
            //        range = new Vector2(min, max)
            //    };
            //    min = max;
            //    max += 20;
            //    buttonRanges.Add(br);
            //}
            
        }

        //Holds button, the range of values that equals it, and possibly a script's activation.
        //I don't know much about the last one there.
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
            //This should set the UI to activate once hooked up
            //var thebutton = GetTheButton(itemValue);
            //if (thebutton != null)
            //{
            //    thebutton.button.SetActive(true);
            //}

            //This should handle the Item Button
            if (Input.GetKeyDown(KeyCode.Return))
            {

                //////////THIS IS LIST OF ITEM USAGE CODE//////////////////////////////////
                //LASER
                if (itemValue >= 21 && itemValue <= 40)
                {
                    //Instatiates one block above
                    GameObject newLaser = Instantiate(LaserPrefab,
                                            new Vector3(car.transform.position.x,
                                            car.transform.position.y + 1,
                                            car.transform.position.z),
                                                car.transform.rotation);
                    //Sets to destroy in 15 seconds
                    Destroy(newLaser, 15);

                    //This setsthe laser's user as the car
                    LaserBehaviour lsrScrpt = newLaser.GetComponent<LaserBehaviour>();
                    lsrScrpt.User = car;

                    //This sets the forward for the laser,
                    //along with the boost to make it not spawn behind the vehicle at high speeds
                    newLaser.transform.forward = car.transform.forward;
                    newLaser.transform.position += newLaser.transform.forward * 5;
                }
                //SHIELD
                if (itemValue >= 41 && itemValue <= 60)
                {
                    car.GetComponent<ShieldBehaviour>().enabled = true;
                    shieldOn = true;
                }
                //BOOST
                if (itemValue >= 61 && itemValue <=80)
                {
                    var boostBehaviour = car.GetComponent<BoostBehaviour>().enabled = true;
                }

                //Still unsure the true purpose of this. I think I have to set a function for the 
                // corresponding button
                //thebutton.Response.Invoke();
            }

            //TEST CODE DO NOT USE, Tests each item individually, before addingto the cycle
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                //LASER TEST CODE (worthless at this point)
                GameObject newRocket = Instantiate(RocketPrefab, new Vector3(car.transform.position.x, 
                                        car.transform.position.y+1, 
                                        car.transform.position.z),
                                            car.transform.rotation);
                TrueMissleBehaviour rktScrpt = newRocket.GetComponent<TrueMissleBehaviour>();
                rktScrpt.User = car.gameObject;
                newRocket.transform.position += newRocket.transform.forward * 5;
            }


            //0      no item
            //1-20   missile
            //21-40  laser
            //41-60  shield
            //61-80  boost
            //81-100 virus

            ///////////////////////////////////////////////////////////////////////////////////////
            //=======UNUSED CODE, BUT GIVES A RELATIVE GUIDE, DELETE LATER ONCE FINISHED===========
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