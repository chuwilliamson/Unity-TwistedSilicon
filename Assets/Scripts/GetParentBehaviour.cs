using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParentBehaviour : MonoBehaviour {

    [SerializeField]
    GameObject parent;

    public GameObject Parent
    {
        get { return parent; }
    }
}
