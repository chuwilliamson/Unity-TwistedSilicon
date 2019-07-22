using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBehaviour : MonoBehaviour
{
    //-16.59
    public void Begin()
    {
        SceneManager.LoadScene(1);
    }

    public void End()
    {
        Application.Quit();
    }
}
