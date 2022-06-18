using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;

    int index = 0;
    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, waypoints[index % waypoints.Length].position) < 0.1) {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { 
            index++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && index != 0)
        {
            index--;
        }

        var step = speed * Time.deltaTime;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[index % waypoints.Length].rotation, step * 3);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index % waypoints.Length].position, step);
    }
}
