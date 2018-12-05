using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private CharacterController2D controller;
    [SerializeField]
    private float runSpeed = 40f;
    [SerializeField]
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        //Get player input
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
    }

    // Update is called once at fixed intervals
    private void FixedUpdate()
    {
        //Apply player input to character physics
        controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
        jump = false;
    }
}
