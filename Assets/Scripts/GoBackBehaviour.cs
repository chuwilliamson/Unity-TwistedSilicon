using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackBehaviour : MonoBehaviour
{
    public void Go()
    {
        SceneManager.LoadScene(0);
    }


    public void GoC()
    {
        SceneManager.LoadScene(4);
    }

    public void Cred()
    {
        SceneManager.LoadScene(5);
    }
}

