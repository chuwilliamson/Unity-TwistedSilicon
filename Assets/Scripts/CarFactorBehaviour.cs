using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarFactorBehaviour : MonoBehaviour
{

    [SerializeField]
    GameObject scrnUI;

    GameObject buttons;

    int itemValue;

    bool shieldOn;

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


        var children = buttons.GetComponentsInChildren<GameObject>();
        int min = 0;
        int max = min + 20;
        foreach (var child in children)
        {
            var br = new ButtonRange
            {
                button = child,
                range = new Vector2(min, max)
            };
            min = max + 1;
            max += 20;

        }
    }

    public class ButtonRange
    {
        public GameObject button;
        public Vector2 range;
        public UnityEngine.Events.UnityEvent Response;
    }
    public ButtonRange GetTheButton(int itemvaluecheck)
    {
        
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

        var thebutton = GetTheButton(itemValue);
        thebutton.button.SetActive(true);
        thebutton.Response.Invoke();
        



        //0 -1 no item
        //1-20 missile
        //21-40 laser
        //41-60 shield
        //61-80 boost
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
