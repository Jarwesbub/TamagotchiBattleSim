using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightEnd : MonoBehaviour
{
    public GameObject parentObject;

    // Update is called once per frame
    void LateUpdate()
    {
        if (PersistentManagerScript.Instance.FightScreen == false)
        {

            //Destroy(parentObject.transform.GetChild(0).gameObject);
            
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            

        }
    }
}
