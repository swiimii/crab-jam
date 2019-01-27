﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed, jumpHeight;
    public Sprite tucked, walking, standing;
    
    private const float baseJumpForce = 2;
    public bool isGrounded = true;

    public CrabBehavior behavior;

    //void Start()
   //{

   // }

    // Update is called once per frame
    void Update()
    {
        behavior.OnUpdate();
        if(Input.GetAxis("Horizontal") > 0)
        {
            behavior.OnMoveRight();
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            behavior.OnMoveLeft();
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            behavior.OnPressUp();
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            behavior.OnPressDown();
        }
        if(Input.GetButtonDown("Jump"))
        {
            behavior.OnJump();
        }
    }
    
    public void Jump()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight * baseJumpForce);
        isGrounded = false;
    }


    // Detect collision exit with floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            behavior.OnHitGround();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
        }
    }

    public void ChangeBehavior(CrabBehavior behavior)
    {
        this.behavior = behavior;
    }
}
        
    


