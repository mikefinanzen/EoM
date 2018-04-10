using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private bool pressed = false;
    private bool left = false;
    private bool right = false;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            if(left == true)
            {
                moveDirection.x = speed/5;
                left = false;

            }
            if(right == true)
            {
                moveDirection.x = -speed /5;
                right = false;
            }
            if (pressed == true)
            {
                moveDirection.y = jumpSpeed;
                pressed = false;
            }



        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Jump()
    {
        pressed = true;
    }
     
    public void goLeft()
    {
        left = true;
    }

    public void goRight()
    {
        right = true;
    }
}
