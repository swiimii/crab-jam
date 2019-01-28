using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public string[] effectedTags;
    public float windSpeed;
    public float interval, windDuration ;
    public AudioSource audioSource;

    private bool isWindBlowing = false;
    private float accelerationFactor = .15f;
    private int direction = 1;
    private double timeCounter;



    private void Update()
    {
        timeCounter += Time.deltaTime;

        //Check if it's time to add wind again. If so, add wind
        if ( !isWindBlowing && timeCounter > interval)
        {

            AddWind(windSpeed);
            timeCounter = 0;
            isWindBlowing = true;
            audioSource.Play();
        }

        //if wind is blowing, accelerate effected objects
        else if (isWindBlowing && timeCounter < windDuration)
        {
            AddWind(windSpeed);
        }
        // if wind duration has expired, stop wind.
        else if ( isWindBlowing && timeCounter > windDuration)
        {
            AddWind(0);
            timeCounter = 0;
            isWindBlowing = false;
            direction *= -1;
            audioSource.Pause();
            audioSource.panStereo *= -1;
            
        }

    }

    private void AddWind(float speed)
    {
        foreach (string tag in effectedTags)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                var rb = obj.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(direction * accelerationFactor * speed, 0));

            }
        }
    }

    public bool isBlowing()
    {
        return isWindBlowing;
    }
    

}
