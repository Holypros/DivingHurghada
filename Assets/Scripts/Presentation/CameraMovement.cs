using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Slide
{
    [SerializeField] public Texture[] Img;
}

public class CameraMovement : MonoBehaviour
{
    [SerializeField] MeshRenderer[] planes;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Slide[] slide;

    int index = 0, counter = 0;
    int speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, waypoints[index % waypoints.Length].position) < 0.1) {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            counter = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && index != 0)
        {
            index--;
            counter = 0;

        }

        var step = speed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[index % waypoints.Length].rotation, step * 3);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index % waypoints.Length].position, step);

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (slide[index].Img.Length != 0 && counter < slide[index].Img.Length-1)
            {
                counter++;
                planes[index].material.mainTexture = slide[index].Img[counter];
                
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (slide[index].Img.Length != 0 && counter > 0)
            {
                counter--;
                planes[index].material.mainTexture = slide[index].Img[counter];
                
            }
        }
    }
}
