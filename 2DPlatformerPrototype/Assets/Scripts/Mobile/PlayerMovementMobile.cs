using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementMobile : MonoBehaviour

//    [SerializeField]
//   private Camera CameraMain;
    
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = CameraMain.ScreenToWorldPoint(touch.position);
//            touchPosition.z = 0f;
//            transform.position = touchPosition;
//        } 
//    }


    {
    [SerializeField]
    private Joystick joystick;
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
        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        //       horizontalMove = joystick.Horizontal * runSpeed;

        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {
            jump = true;
        }
        if (verticalMove <= -.5f)
        {
            crouch = true;
        }
        else
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

    public void AButtonDown()
    {
        jump = true;
    }
}

