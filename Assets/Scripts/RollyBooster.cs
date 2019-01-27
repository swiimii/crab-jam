using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyBooster : MonoBehaviour
{
    public GameObject player;
    public Vector2 boostingVelocity;
    public int radius;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position, GetComponent<Transform>().position);
        if (distanceToPlayer < radius)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = rb.velocity + boostingVelocity;
        }
    }
}
