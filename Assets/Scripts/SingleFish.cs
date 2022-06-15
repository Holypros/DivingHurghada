using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFish : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    private int Index = 0;
    private float _speed = 5f;

    private void Update()
    {
        Transform p = points[Index];
        if (Vector3.Distance(transform.position, p.position) < 0.01f)
        {
            Index = (Index + 1) % points.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                p.position,
                _speed * Time.deltaTime);
        }
    }
}
