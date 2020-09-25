using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRacket : racket
{
    Transform Ball { get { return  FindObjectOfType<ball>().transform; } }
    protected override void Move()
    {
        //float distance = Vector2.Distance(Ball.position, transform.position); sadece bunu kullanarakta yapabiliriz.
        float distance = Mathf.Abs(transform.position.y-Ball.position.y);
        float horizontalDistances = Mathf.Abs(transform.position.x - Ball.position.x);
        if (distance>2.5f && horizontalDistances<15)
        {
            if (Ball.position.y>transform.position.y)
            {
                rbb2.velocity = Vector2.up * moveSpeed;
            }
            else
            {
                rbb2.velocity = Vector2.down * moveSpeed;
            }

        }
    }

}
