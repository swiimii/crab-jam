using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kickable : MonoBehaviour
{
    public int kickSpeed;
    public int slowdownSpeed;

    // Detect collision exit with floor
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            int dir = (int)Mathf.Sign(GetComponent<Transform>().position.x - collision.gameObject.GetComponent<Transform>().position.x);
            rb.velocity = rb.velocity + new Vector2(kickSpeed*dir, 0);
        }
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(Mathf.Abs(rb.velocity.x) > 0.1)
        {
            rb.velocity = rb.velocity - new Vector2(slowdownSpeed * Mathf.Sign(rb.velocity.x), 0);
        }
        else if (Mathf.Abs(rb.velocity.x) > 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
    }

}
