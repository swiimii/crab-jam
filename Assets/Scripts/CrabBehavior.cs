﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehavior
{
    internal PlayerController2D player;

    public CrabBehavior(PlayerController2D player)
    {
        this.player = player;
    }

    public virtual void OnUpdate()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(move.x * player.moveSpeed, rb.velocity.y);
        if(player.GetComponent<SpriteRenderer>().sprite == player.walking)
        {
            player.GetComponent<Animator>().speed = player.isGrounded ? Mathf.Abs(Input.GetAxisRaw("Horizontal")) : 0;
        }
    }

    public virtual void OnMoveLeft()
    {
        if(player.isGrounded)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public virtual void OnMoveRight()
    {
        if(player.isGrounded)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public virtual void OnJump()
    {
        if(player.isGrounded)
        {
            player.Jump();
        }
    }

    public virtual void OnPressUp()
    {

    }

    public virtual void OnPressDown()
    {

    }

    public virtual void OnHitGround()
    {

    }
}