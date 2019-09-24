using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float slideMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool InSlide { get; set; }
    Direction lastDirection;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove > 0)
        {
            lastDirection = Direction.Right;
        } else if (horizontalMove < 0)
        {
            lastDirection = Direction.Left;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate() {

        if (InSlide)
        {
            controller.Move(slideMove * Time.fixedDeltaTime, crouch, jump);
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        }
        
        jump = false;
    }

    public void Slide()
    {
        if (InSlide)
            return;

        switch (lastDirection)
        {
            case Direction.Left:
                slideMove = -runSpeed; break;
            case Direction.Right:
                slideMove = runSpeed; break;
            default: break;
        }

        InSlide = true;
    }
}
