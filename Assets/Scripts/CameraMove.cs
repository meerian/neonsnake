using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 startpos;
    private Vector3 newpos;

    public GameObject snake;

    // Movement speed in units per second.
    public float speed;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private void Start()
    {
        startTime = Time.time;
        startpos = transform.position;
        newpos = snake.transform.position;
        journeyLength = Vector3.Distance(startpos, newpos);
    }

    private void Update()
    {
            newpos = snake.transform.position;
            journeyLength = Vector3.Distance(startpos, newpos);
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startpos, newpos, fractionOfJourney);
    }

    public void SetNewPosition(Vector3 pos)
    {
        startpos = transform.position;
        newpos = pos;
        journeyLength = Vector3.Distance(startpos, newpos);
    }
}
