using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed, jumpHeight;
    public Camera cam;
    public Sprite tucked, walking, standing;

    private const float baseJumpForce = 80;
    private bool isTucked = false, isGrounded = true;

    private CrabBehavior behavior;

    void Start()
    {
        ChangeBehavior(new RollyCrab(this));
    }

    // Update is called once per frame
    void Update()
    {
        behavior.OnUpdate();
        if(Input.GetAxis("Horizontal") > 0)
        {
            behavior.OnMoveRight();
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            behavior.OnMoveLeft();
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            behavior.OnPressUp();
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            behavior.OnPressDown();
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            behavior.OnJump();
        }
    }
    
    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpHeight * baseJumpForce);
        isGrounded = false;
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

    public void ChangeBehavior(CrabBehavior behavior)
    {
        this.behavior = behavior;
    }
}
        
    


