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
        player.transform.SetPositionAndRotation(player.transform.position, new Quaternion());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(!doubleJumpLeft)
        {
            player.transform.Rotate(Vector3.forward, player.GetComponent<SpriteRenderer>().flipX ? 5 : -5);
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