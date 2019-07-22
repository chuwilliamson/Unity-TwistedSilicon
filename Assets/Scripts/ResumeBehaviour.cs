using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBehaviour : MonoBehaviour
{
    public GameObject Holder;

    public void ResumeGame()
    {
        Holder.GetComponent<DeathWallBehaviour>().paused = false;
    }
}
