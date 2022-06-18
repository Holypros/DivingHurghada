using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFish : MonoBehaviour
{
    public Transform[] points;
    int n = 0;
    float speed = 5f;

    private void Update()
    {
        Transform p = points[n];
        if (Vector3.Distance(transform.position, p.position) < 0.01f)
        {
            n = (n + 1) % points.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, p.position, speed * Time.deltaTime);
            transform.LookAt(points[n]);

        }
    }
}
