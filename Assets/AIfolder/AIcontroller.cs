using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : MonoBehaviour
{
    [SerializeField] GameObject point;
    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, point.transform.position, speed * Time.deltaTime);

    }
}
