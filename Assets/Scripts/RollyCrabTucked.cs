﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyCrabTucked : CrabBehavior
{
    public RollyCrabTucked(PlayerController2D player) : base(player) { }
   
    public override void OnPressUp()
    {
        //Untuck
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<SpriteRenderer>().sprite = player.walking;
        player.GetComponent<Transform>().SetPositionAndRotation(player.transform.position, Quaternion.identity);
        var rb = player.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.velocity *= .3f;
        player.ChangeBehavior(new RollyCrab(player));
    }

    public override void OnUpdate()
    {

    }

    public override void OnMoveLeft()
    {

    }

    public override void OnMoveRight()
    {

    }
}