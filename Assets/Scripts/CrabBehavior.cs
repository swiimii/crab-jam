using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CrabBehavior
{
    internal PlayerController2D player;

    public CrabBehavior(PlayerController2D player)
    {
        this.player = player;
    }

    public virtual void OnUpdate()
    {
        player.transform.position += new Vector3(Input.GetAxis("Horizontal") * player.moveSpeed * Time.deltaTime, 0, 0);
        if(player.GetComponent<SpriteRenderer>().sprite == player.walking)
        {
            player.GetComponent<Animator>().speed = Mathf.Abs(Input.GetAxis("Horizontal"));
        }
    }

    public virtual void OnMoveLeft()
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
    }

    public virtual void OnMoveRight()
    {
        player.GetComponent<SpriteRenderer>().flipX = false;
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