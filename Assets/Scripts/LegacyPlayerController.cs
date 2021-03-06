﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyPlayerController : MonoBehaviour
{
    public float moveSpeed, jumpHeight;
    public Camera cam;
    public Sprite tucked, walking, standing;
    public GameObject Shell;

    private const float baseJumpForce = 2;
    private bool isTucked = false, isGrounded = true;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTucked)
        {

            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);

            //GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * Input.GetAxis("Horizontal"), 0));
            if (GetComponent<SpriteRenderer>().sprite == walking)
            {
                GetComponent<Animator>().speed = Mathf.Abs(Input.GetAxis("Horizontal"));
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetButton("Jump") && isGrounded == true)
            {
                Jump();
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                Tuck();
            }
        }

        else if (isTucked)
        {

            if (Input.GetButton("Jump") && isGrounded == true)
            {
                Jump();
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                UnTuck();
            }
        }
    }


    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight * baseJumpForce);
        isGrounded = false;
        //print("Jump");
    }

    void Tuck()
    {

        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = tucked;
        var rb = GetComponent<Rigidbody2D>();
        isTucked = true;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        GetComponent<Rigidbody2D>().freezeRotation = false;
    }

    void UnTuck()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = walking;
        GetComponent<Transform>().SetPositionAndRotation(transform.position, Quaternion.identity);
        var rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.velocity = new Vector2(rb.velocity.x * 0.3f, rb.velocity.y * 0.3f);
        isTucked = false;
    }


    // Detect collision exit with floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
        }
    }




}




