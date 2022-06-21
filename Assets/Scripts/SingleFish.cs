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

            var targetRotation = Quaternion.LookRotation(points[n].transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
           

        }
    }
}
