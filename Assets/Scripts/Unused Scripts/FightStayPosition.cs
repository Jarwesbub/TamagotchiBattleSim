using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class FightStayPosition : MonoBehaviour
{

        //GetComponent<Animator>().transform.parent.position = GetComponent<Animator>().transform.position;

    void LateUpdate()
    {
        //OnAnimatorMove();

        //GetComponent<Animation>().

       // GetComponent<Animation>().play("warrior_idle");

        //animation["warrior_idle"].WrapMode = WrapMode.Loop;

    }


    void OnAnimatorMove()
    {
        transform.parent.rotation = GetComponent<Animator>().rootRotation;
        transform.parent.position += GetComponent<Animator>().deltaPosition;
    }



}
