using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritHitController : MonoBehaviour
{
    public GameObject CritHitObject;

    // Update is called once per frame
    void Update()
    {
        if (PersistentManagerScript.Instance.IsCritical == true)
        {
            
            StartCoroutine(CritHitStart());

        }
        else
        {
            CritHitObject.SetActive(false);
        }
        if (PersistentManagerScript.Instance.IsCritical == false)
        {
            CritHitObject.SetActive(false);

        }


    }

    IEnumerator CritHitStart()
    {
        CritHitObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        PersistentManagerScript.Instance.IsCritical = false;
        CritHitObject.SetActive(false);
    }


}
