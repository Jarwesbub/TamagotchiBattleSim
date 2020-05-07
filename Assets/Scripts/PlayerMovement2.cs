using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;


    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        moveVertical = Input.GetAxis("Vertical") * moveSpeed;


        movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * moveSpeed;


    }







}



