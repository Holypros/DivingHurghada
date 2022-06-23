using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public struct Slide
{
    [SerializeField] public Material[] Img;
}

public class CameraMovement : MonoBehaviour
{
    [SerializeField] MeshRenderer[] planes;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Slide[] slide;

    int index = 0;
//    [SerializeField] int speed = 10;
//    [SerializeField] int rotationSpeed = 30;
    int[] counterSlides;

    [SerializeField] float[] Slides_Speed;
//    [SerializeField] float[] Slides_Rotation_Speed;
//    int Counter_Slides_Speed = 0;

    void Start()
    {
        counterSlides = new int[planes.Length];
//      Counter_Slides_Speed = new int[planes.Length];

    }

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

//      transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[index].rotation, rotationSpeed * Time.deltaTime);
//      transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
//      transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[index].rotation, Slides_Rotation_Speed[index] * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, Slides_Speed[index] * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (slide[index].Img.Length != 0 && counterSlides[index] < slide[index].Img.Length-1)
            {
                counterSlides[index]++;
                planes[index].material = slide[index].Img[counterSlides[index]];
                
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (slide[index].Img.Length != 0 && counterSlides[index] > 0)
            {
                counterSlides[index]--;
                planes[index].material = slide[index].Img[counterSlides[index]];
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
