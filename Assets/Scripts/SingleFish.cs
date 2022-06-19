using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFish : MonoBehaviour
{
    public Transform[] points;
    int n = 0;
    float speed = 3f;
    float b;
    private void Update()
    {
        Transform p = points[n];

        if (Vector3.Distance(transform.position, p.position) < 0.01f)
        {
            b = 0;
            n = (n + 1) % points.Length;
        }
        else 
        {

            transform.position = Vector3.MoveTowards(transform.position, p.position, speed * Time.deltaTime);

            if (b <= 1)
            {
                b += 0.01f;
            }
            Vector3 lerp = Vector3.Lerp(points[n].position, points[n + 1].position, b);
            transform.LookAt(lerp);


        }
    }
}
