using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopColliderSwitcher : MonoBehaviour
{
    public GameObject player;
    public GameObject trackToTurnOff;
    public GameObject trackToTurnOn;
    private bool flipped;
    public int radius;
    private void Start()
    {
        flipped = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!flipped)
        {
            float distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position, GetComponent<Transform>().position);
            if (distanceToPlayer < radius)
            {
                trackToTurnOff.GetComponent<PolygonCollider2D>().enabled = false;
                trackToTurnOn.GetComponent<PolygonCollider2D>().enabled = true;
                flipped = true;
            }
        }
        
    }
}
