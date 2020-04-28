using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{


    public void GoToTamaMenuScene()
    {
        SceneManager.LoadScene("TamaMenuScene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
    public void GoToWorld1Scene()
    {
        SceneManager.LoadScene("World1Scene");
        //PersistentManagerScript.Instance.Str++; //test add 1

    }
}
