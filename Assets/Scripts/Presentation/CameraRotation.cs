using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//[System.Serializable]

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;

    int index = 0;
    [SerializeField] float[] Slides_Rotation_Speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            index %= waypoints.Length;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && index != 0)
        {
            index--;
            index %= waypoints.Length;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[index].rotation, Slides_Rotation_Speed[index] * Time.deltaTime);

    }
}
