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

    }

    public virtual void OnMoveLeft()
    {
        player.transform.position -= new Vector3(player.moveSpeed * Time.deltaTime, 0, 0);
        player.GetComponent<SpriteRenderer>().flipX = true;
    }

    public virtual void OnMoveRight()
    {
        player.transform.position += new Vector3(player.moveSpeed * Time.deltaTime, 0, 0);
        player.GetComponent<SpriteRenderer>().flipX = false;
    }

    public virtual void OnJump()
    {
        player.Jump();
    }

    public virtual void OnPressUp()
    {

    }

    public virtual void OnPressDown()
    {

    }
}