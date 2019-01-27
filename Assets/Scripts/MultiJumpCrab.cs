using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiJumpCrab : CrabBehavior
{
    private float rotateSpeed = 50;
    private const float initalRotateSpeed = 50, rotationReductionConstant = .30f;
    private int jumps, multiJumpsLeft;


    public MultiJumpCrab(PlayerController2D player, int jumpsInput) : base(player)
    {
        multiJumpsLeft = jumpsInput;
        jumps = jumpsInput;
    }

    public override void OnHitGround()
    {
        multiJumpsLeft = jumps;
        rotateSpeed = initalRotateSpeed;
        player.transform.SetPositionAndRotation(player.transform.position, new Quaternion());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (multiJumpsLeft < jumps)
        {
            player.transform.Rotate(Vector3.forward, player.GetComponent<SpriteRenderer>().flipX ? rotateSpeed : -rotateSpeed);
            rotateSpeed -= rotateSpeed * rotationReductionConstant * Time.deltaTime;
        }
    }

    public override void OnJump()
    {
        if (player.isGrounded || multiJumpsLeft > 0)
        {
            multiJumpsLeft--;
            player.Jump();
        }
    }
}
