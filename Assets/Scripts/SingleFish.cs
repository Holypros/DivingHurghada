using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFish : MonoBehaviour
{
    public Transform[] points;
    int n = 0;
    float speed = 3f;
    float b;
    Vector3 lerp;
    private void Update()
    {
        Transform p = points[n];

        if (Vector3.Distance(transform.position, p.position) < 0.01f)
        {
            n = (n + 1) % points.Length;

            b = 0;
        }
        else 
        {

            transform.position = Vector3.MoveTowards(transform.position, p.position, speed * Time.deltaTime);

            if (b <= 1)
            {
                b += 0.01f;
            }

            if ( n <= points.Length)
            {
               lerp = Vector3.Lerp(points[n].position, points[n].position, b);
               
            }

            transform.LookAt(lerp);

        }
    }
}
