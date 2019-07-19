using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPointBehaviour : MonoBehaviour
{
    

    [SerializeField]
    GameObject car;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(car.transform.position.x, transform.position.y, car.transform.position.z);
        transform.rotation = new Quaternion(transform.rotation.x, car.transform.rotation.y, transform.rotation.z, transform.rotation.w);

    }
}
