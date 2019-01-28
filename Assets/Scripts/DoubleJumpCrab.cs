using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCrab : CrabBehavior
{
    private float rotateSpeed = 50;
    private const float initalRotateSpeed = 50, rotationReductionConstant = .30f;
    private bool doubleJumpLeft = true;
    

    public DoubleJumpCrab(PlayerController2D player) : base(player) { }
    
    public override void OnHitGround()
    {
        doubleJumpLeft = true;
        rotateSpeed = initalRotateSpeed;
        player.transform.SetPositionAndRotation(player.transform.position, new Quaternion());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(!doubleJumpLeft)
        {
            player.transform.Rotate(Vector3.forward, player.GetComponent<SpriteRenderer>().flipX ? rotateSpeed : -rotateSpeed);
            rotateSpeed -= rotateSpeed * rotationReductionConstant * Time.deltaTime;
        }
    }

    public override void OnJump()
    {
        if(player.isGrounded || doubleJumpLeft)
        {
            if(!player.isGrounded)
            {
                doubleJumpLeft = false;
            }
            player.Jump();
        }
    }
}