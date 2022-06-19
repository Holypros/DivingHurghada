using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFish : MonoBehaviour
{
    public Transform[] points;
    int n = 0;
    float speed = 3f;
    Quaternion rot;
    Vector3 dir;

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
            //dir = (points[n].position - points[n-1].position).normalized;
            //rot = Quaternion.LookRotation(dir);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.3f);
            transform.LookAt(points[n]);

        }
    }
}
