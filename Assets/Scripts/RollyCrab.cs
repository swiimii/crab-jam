using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyCrab : CrabBehavior
{
    public RollyCrab(PlayerController2D player) : base(player) { }

    public override void OnPressDown()
    {
        //Tuck
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<SpriteRenderer>().sprite = player.tucked;
        var rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * player.moveSpeed, rb.velocity.y);
        player.GetComponent<Rigidbody2D>().freezeRotation = false;
        player.ChangeBehavior(new RollyCrabTucked(player));
    }

    public override void OnUpdate()
    {
        if(player.GetComponent<SpriteRenderer>().sprite == player.walking)
        {
            player.GetComponent<Animator>().speed = Mathf.Abs(Input.GetAxis("Horizontal"));
        }
    }
}