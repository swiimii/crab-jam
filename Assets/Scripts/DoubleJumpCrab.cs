using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCrab : CrabBehavior
{
    private bool doubleJumpLeft = true;

    public DoubleJumpCrab(PlayerController2D player) : base(player) { }
    
    public override void OnHitGround()
    {
        doubleJumpLeft = true;
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